SRCDIR := src
OBJDIR := obj
INCDIR := inc
BINDIR := bin

CC := gcc
CFLAGS := -lm -I$(INCDIR)

all: $(BINDIR)/float_entropy $(BINDIR)/int_entropy

# Make the float_entropy binary
$(BINDIR)/float_entropy: $(OBJDIR)/float_entropy.o $(OBJDIR)/entropy.o
	$(CC) -o \
	$(BINDIR)/float_entropy \
	$(SRCDIR)/float_entropy.c \
	$(SRCDIR)/entropy.c \
	$(CFLAGS)

# Make the int_entropy binary
$(BINDIR)/int_entropy: $(OBJDIR)/int_entropy.o $(OBJDIR)/entropy.o
	$(CC) -o \
	$(BINDIR)/int_entropy \
	$(SRCDIR)/int_entropy.c \
	$(SRCDIR)/entropy.c \
	$(CFLAGS)

# Make the object files
$(OBJDIR)/%.o: $(SRCDIR)/%.c
	$(CC) $(CFLAGS) -c $< -o $@

# Clean the project by removing .o files
clean:
	rm -f $(OBJDIR)/*.o