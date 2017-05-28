# Install Software
sudo apt-get update
sudo apt-get upgrade -y
sudo apt-get dist-upgrade -y
sudo apt-add-repository ppa:ansible/ansible -y
sudo apt-get update
sudo apt-get install ansible -y
sudo apt-get install git -y

# Setup SSH for git
sudo chmod 700 /home/vagrant/.ssh
sudo chmod 600 /home/vagrant/.ssh/id_rsa
sudo chmod 644 /home/vagrant/.ssh/id_rsa.pub
eval `ssh-agent -s`
ssh-add /home/vagrant/.ssh/id_rsa
ssh-keyscan -H github.iu.edu >> /home/vagrant/.ssh/known_hosts

# Clone the ehc repository
git clone git@github.iu.edu:rehann/ehc.git /home/vagrant/ehc

# Disable key checking so the playbook can run automatically
export ANSIBLE_HOST_KEY_CHECKING=False

# Run the ehc playbook
ansible-playbook ehc/site.yml -i ehc/inventory