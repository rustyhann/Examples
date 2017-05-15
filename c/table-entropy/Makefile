SRCDIR := src
OBJDIR := obj
INCDIR := inc
BINDIR := bin

CC := gcc
CFLAGS := -lm -I$(INCDIR)

all: $(BINDIR)/float_entropy $(BINDIR)/int_entropy

$(BINDIR)/float_entropy: $(OBJDIR)/float_entropy.o $(OBJDIR)/entropy.o
	$(CC) -o \
	$(BINDIR)/float_entropy \
	$(SRCDIR)/float_entropy.c \
	$(SRCDIR)/entropy.c \
	$(CFLAGS)

$(OBJDIR)/%.o: $(SRCDIR)/%.c
	$(CC) $(CFLAGS) -c $< -o $@

$(BINDIR)/int_entropy: $(OBJDIR)/int_entropy.o $(OBJDIR)/entropy.o
	$(CC) -o \
	$(BINDIR)/int_entropy \
	$(SRCDIR)/int_entropy.c \
	$(SRCDIR)/entropy.c \
	$(CFLAGS)

# Clean the project by removing .o files
clean:
	rm -f $(OBJDIR)/*.o