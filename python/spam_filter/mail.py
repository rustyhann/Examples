#!/usr/local/bin/python3
import os
import re
import nltk


class Mail(object):

    def __init__(self, directory):
        self.dir_data = directory
        self.dir_spam = directory + os.path.sep + 'spam'
        self.dir_notspam = directory + os.path.sep + 'notspam'
        self.dir_clean_spam = directory + os.path.sep + 'clean_spam'
        self.dir_clean_notspam = directory + os.path.sep + 'clean_notspam'

    def clean(self):
        # Create needed directories if they do not exist
        self.create_directory(self.dir_clean_spam)
        self.create_directory(self.dir_clean_notspam)

        # # Clean the spam and notspam files
        self.clean_mail(self.dir_spam, self.dir_clean_spam)
        self.clean_mail(self.dir_notspam, self.dir_clean_notspam)

    def create_directory(self, directory):
        if not os.path.exists(directory):
            os.makedirs(directory)

    def clean_mail(self, source_directory, clean_directory):
        if len(os.listdir(clean_directory)) > 0:
            return
        for filename in os.listdir(source_directory):

            # Determine the full path to the source and clean files
            source_fullname = source_directory + '/' + filename
            clean_fullname = clean_directory + '/' + filename

            # clean the file if it has not already been cleaned, a file is
            # considered cleaned if it exists in one of the clean directories
            if not os.path.exists(clean_fullname):

                print("Cleaning: " + filename)

                # Open the current file and store the data in content
                with open(source_fullname, 'r', encoding='latin1') as file:
                    content = file.read()

                # Run the clean functions
                content = self.remove_html(content)
                content = self.remove_numbers(content)
                content = self.remove_characters(content)
                content = self.remove_stop_words(content)
                content = self.remove_single_characters(content)
                content = self.remove_nonsense(content)
                content = self.lower(content)

                # Write the clean file
                with open(clean_fullname, 'w', encoding='latin1') as file:
                    file.write(content)

    def remove_html(self, content):
        # Remove all HTML tags which are defined as any word that starts with
        # < and ends with >, if there is data between the tags, such as
        # <h1>Title</h1>, 'Title' will NOT be removed
        return re.sub('<[^>]*>', ' ', content)

    def remove_numbers(self, content):
        # Remove all numbers and replace them with spaces
        return re.sub('[0-9]', ' ', content)

    def remove_characters(self, content):
        # Remove all special characters and replace them with spaces
        return re.sub('[\[\]$&+,:;=?@#|\\\/\'_<>.^*()%!"\-]', ' ', content)

    def remove_stop_words(self, content):
        # Remove stop words
        tokenizer = nltk.RegexpTokenizer(r'[A-Za-z]+')
        tokens = tokenizer.tokenize(content)
        stop = nltk.corpus.stopwords.words('english')
        return " ".join([word for word in tokens if word.lower() not in stop])

    def remove_single_characters(self, content):
        # Remove single characters
        tokens = nltk.word_tokenize(content)
        return " ".join([word for word in tokens if len(word) > 2])

    def remove_duplicates(self, content):
        # Remove duplicates, this isn't currently used
        return set([word for word in nltk.word_tokenize(content)])

    def remove_nonsense(self, content):
        return ' '.join([word for word in nltk.word_tokenize(content)])

    def lower(self, content):
        return ' '.join([word.lower() for word in content.split()])
