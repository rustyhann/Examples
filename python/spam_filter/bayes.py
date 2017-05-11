#!/usr/local/bin/python3
import os
import mail
import nltk
import math
import tabulate
import json


class Bayes(mail.Mail):

    def __init__(self, train, file):
        self.mail = mail.Mail(train)       # Create a mail object
        self.corpus = self.get_corpus()    # Brown corpus, lower case only
        self.spam = {}                     # Dictionary containing word : count
        self.notspam = {}                  # Dictionary containing word : count
        self.results = []                  # Results of testing for spam
        self.correct = 0.0                 # Correct number of emails
        self.correct_pct = 0.0             # Correct percentage
        self.incorrect = 0.0               # Incorrect number of emails
        self.incorrect_pct = 0.0           # Incorrect percentage
        self.total = 0.0                   # Total number of predictions
        self.model = {}
        self.model_json = ""
        self.model_file = os.getcwd() + '/' + file
        self.spam_count = 0.0
        self.notspam_count = 0.0
        self.predicted_spam = 0.0
        self.predicted_notspam = 0.0
        self.correct_spam = 0.0
        self.incorrect_spam = 0.0
        self.correct_notspam = 0.0
        self.incorrect_notspam = 0.0

    def output(self):
        print("Accuracy:{0}%".format(str(round(self.correct_pct * 100, 2))))
        confusion_headers = ["", "Spam", "NotSpam"]
        confusion_matrix = []
        confusion_matrix.append(["Predicted", self.predicted_spam, self.predicted_notspam])
        confusion_matrix.append(["Correct", self.correct_spam,self.incorrect_notspam])
        confusion_matrix.append(["Incorrect", self.incorrect_spam, self.incorrect_notspam])
        confusion_matrix.append(["Total", self.spam_count, self.notspam_count])
        print(tabulate.tabulate(confusion_matrix, confusion_headers))

    def train(self):
        self.mail.clean()
        self.train_email("spam")
        self.train_email("notspam")
        self.write_model()

    def train_email(self, spam_type):
        # Determine the directory the training files are in based by spam_type

        # spam
        if spam_type == 'spam':
            directory = self.mail.dir_clean_spam

        # not spam
        if spam_type == 'notspam':
            directory = self.mail.dir_clean_notspam

        # Loop through each training spam message
        for filename in os.listdir(directory):

            # Determine the full path to the file
            fullname = directory + '/' + filename

            # Open the current file and store the data in content
            with open(fullname, 'r', encoding='latin1') as content_file:
                content = content_file.read()

            # Split the file contents on space to get individual words and get
            # the count of total words in the email before filteirng out words
            # not in the brown corpus. Update the total_word count by adding
            # the total word count in the email.
            words = content.split()
            words_count = float(len(words))

            # Remove words not in the Brown corpus and get the new count
            # The remaining natural words, meaning words in the Brown corpus,
            # are a high indication of not spam
            natural_words = list(set(words) & self.corpus)
            natural_words_count = float(len(natural_words))

            # The difference between words_count and natural_words_count is the
            # number of nonsense words removed from the email. Those are now
            # added to the spam dictionary as _INVALID. The number of invalid
            # words in an email is a accurate marker for spam
            invalid_words_count = float(words_count - natural_words_count)

            # Update the training objects with the _INVALID count

            # spam
            if spam_type == 'spam':
                if '_INVALID' in self.spam:
                    self.spam['_TOTAL'] += words_count
                    self.spam['_INVALID'] += invalid_words_count
                else:
                    self.spam.update({'_TOTAL': words_count})
                    self.spam.update({'_INVALID': invalid_words_count})

            # notspam
            if spam_type == 'notspam':
                if '_INVALID' in self.notspam:
                    self.notspam['_TOTAL'] += words_count
                    self.notspam['_INVALID'] += invalid_words_count
                else:
                    self.notspam.update({'_TOTAL': words_count})
                    self.notspam.update({'_INVALID': invalid_words_count})

            # Loop through each word in the email and classify it as spam
            for word in natural_words:

                # Update the training dictionaries based on spam_type

                # spam
                if spam_type == 'spam':
                    if word in self.spam:
                        self.spam[word] += 1.0
                    else:
                        self.spam.update({word: 1.0})

                # notspam
                if spam_type == 'notspam':
                    if word in self.notspam:
                        self.notspam[word] += 1.0
                    else:
                        self.notspam.update({word: 1.0})

        # Now go through each word and calculate the probability of each word
        # being spam or notspam using '_TOTAL' Probabilities will be stored as
        # logs so the numbers are not extremely small, as an example 0.00027

        # spam
        if spam_type == 'spam':
            total = self.spam['_TOTAL']
            for key, value in self.spam.items():
                if key != '_TOTAL':
                    self.spam[key] = round(math.log(value / total), 2)

        # notspam
        if spam_type == 'notspam':
            total = self.notspam['_TOTAL']
            for key, value in self.notspam.items():
                if key != '_TOTAL':
                    self.notspam[key] = round(math.log(value / total), 2)

    def write_model(self):
        self.model.update({'spam': self.spam})
        self.model.update({'notspam': self.notspam})
        self.model_json = json.dumps(self.model, ensure_ascii=True)
        with open(self.model_file, 'w') as outfile:
            json.dump(self.model_json, outfile)

    def test(self):
        self.load_model()
        self.test_email("spam")
        self.test_email("notspam")

    def load_model(self):
        with open(self.model_file, 'r') as infile:
            self.model = json.loads(json.load(infile))
        self.spam = self.model['spam']
        self.notspam = self.model['notspam']

    def test_email(self, spam_type):

        # Determine the directory the training files are in based by spam_type

        # spam
        if spam_type == 'spam':
            directory = self.mail.dir_clean_spam

        # not spam
        if spam_type == 'notspam':
            directory = self.mail.dir_clean_notspam

        # Loop through each training spam message
        for filename in os.listdir(directory):

            # declare and initialize the spam scores for this directory
            spam_score = 0.0
            notspam_score = 0.0

            # Determine the full path to the file
            fullname = directory + '/' + filename

            # Open the current file and store the data in content
            with open(fullname, 'r', encoding='latin1') as content_file:
                content = content_file.read()

            # Split the file contents on space to get individual words and get
            # the count of total words in the email before filteirng out words
            # not in the brown corpus.
            words = content.split()
            words_count = float(len(words))

            # Remove words not in the Brown corpus and get the new count
            # We are comparing only natural words (words in the Brwown corpus)
            # because we have already accounted for nonsense words above
            natural_words = list(set(words) & self.corpus)
            natural_words_count = float(len(natural_words))

            # The difference between words_count and natural_words_count is the
            # number of nonsense words removed from the email.
            invalid_words_count = int(words_count - natural_words_count)

            # Add the _INVALID values to the spam and not spam scores. Both
            # spam and notspam emails can have invalid words, but, spam emails
            # have a much large probability of having them. Therefore, each
            # invalid word will heavily penalize an email as being spam.
            for invalid_word in range(0, invalid_words_count):
                spam_score += self.spam['_INVALID']
                notspam_score += self.spam['_INVALID']

            # Determine the spam score per natural word for this email.
            # Natural words are words found in the Brown corpus
            for word in natural_words:

                # Check to see if the word is in the appropriate training set.
                # Some words will be in notspam emails, but not spam emails,
                # and vice-versa. If an email is in one set, but not the other,
                # we are still adding it to the score. If a word is not in
                # either training set, it is simply not added.
                if word in self.spam:
                    spam_score += self.spam[word]

                if word in self.notspam:
                    notspam_score += self.notspam[word]

            # Determine if the email is spam or notspam by selecting the lower
            # value. A tie goes to notspam.
            if notspam_score >= spam_score:
                prediction = 'notspam'
                self.predicted_notspam += 1.0
            else:
                prediction = 'spam'
                self.predicted_spam += 1.0

            # Determine if the classification is correct
            if spam_type == prediction:
                correct = True
                self.correct += 1
                if spam_type == 'spam':
                    self.correct_spam += 1.0

                if spam_type == 'notspam':
                    self.correct_notspam+= 1.0
            else:
                correct = False
                self.incorrect += 1
                if spam_type == 'spam':
                    self.incorrect_spam += 1.0

                if spam_type == 'notspam':
                    self.incorrect_notspam += 1.0

            # Stats
            if spam_type == 'spam':
                self.spam_count += 1.0

            if spam_type == 'notspam':
                self.notspam_count += 1.0

            self.total += 1.0

        self.correct_pct = round(self.correct / self.total, 2)
        self.incorrect_pct = round(self.incorrect / self.total, 2)


    def get_corpus(self):
        return set(w.lower() for w in nltk.corpus.brown.words())
