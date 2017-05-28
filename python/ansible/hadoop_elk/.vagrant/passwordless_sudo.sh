# Passwordless sudo for vagrant and Ansible
sudo sed -i 's/%admin ALL=(ALL) ALL/%admin ALL=(ALL) NOPASSWD:ALL/g' /etc/sudoers
sudo usermod -a -G admin vagrant