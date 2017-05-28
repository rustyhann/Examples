Elastic Hadoop
=========

This playbook installs Hadoop, Yarn, Flume, Elasticsearch, and Kibana to provide large sacel log
analysis.

Requirements
------------

Windows 10
Vagrant 1.8.1 with the latest ubuntu/trusty64 box
VirtualBox 5.0.20

Instructions
--------------

Clone the repository from the following URL:

https://github.iu.edu/rehann/ehc.git

You will need to edit the Vagrant file and the inventory file to match your network.

By default four machines are created on the 19.168.11.0/24 subnet. These machines are placed on a
bridged network adapter and assigend static IP addresses in the 192.168.11.0/24 subnet. You will
need to edit the IP addresses in the Vagrant file and the inventory file to work with your network.
Please be careful of DHCP conflicts if you are on a network with a large amount of hosts. The
default IP Addresses are:

ehcAdmin 192.168.11.50
ehc01 192.168.11.51
ehc02 192.168.11.52
ehc03 192.168.11.53

If you have not initialized the ubutu/trusty64 box, please do so. Once initialized, you only need to
run vagrant up and all of the required virtual machines will be created with software installed.

The example_output.log file in the .vagrant directory shows what a full run should look like if
successful.

Vagrant Notes
------------

Vagrant takes care of setting up passwordless sudo for the Vagrant user for Anisble. This allows the
same user to be used for running Vagrant and Ansible. Because the entire process is ran under the
Vagrant user, the Ansible playbook is automatically ran as the last step in the Vagrant setup.

Vagrant also installs Ansible and all needed dependencies on the Admin machine.

Ansible Notes
-------------

Ansible setup is handled by the Vagrant scripts and the playbook is automatically ran as the last
step in the deployment process. The Ansible playbook is ran from the Admin machine with ehc01-03 as
targets.

Hadoop / Yarn Notes
-------------------

Hadoop is setup as a cluster and runs under the hadoop user context. Ech01 is the master node and
ech02 and ech03 are slave nodes. Hadoop is installed in /usr/local/hadoop on all machines.

An init file is provided for Hadoop and Yarn so that they will start at system boot. Hadoop has boot
dependencies on rsyslog and ssh. Yarn has a boot dependency on hadoop.

The hadoop interface can be accessed using the hadoop url and port 50070. Using the example IP
addresses above, the url would be 192.168.11.51:50070.

Once the cluster is up and running you can view logs stored in HDFS with the following command:

hdfs dfs -ls /syslog

This command needs to be ran as the hadoop user from the master node. The hadoop user password is:

'password'

A quick way to generate data in hdfs is to start remote sessions to all three cluster nodes. The
ssh logs will be written to HDFS via rsyslog and flume in a short amount of time.

Flume Notes
-----------

Flume is installed in /user/local/flume on the master node. A single flume agent has been configured
to receive syslog data and write it to HDFS. An init script has been provided to allow the Flume
agent to start at system startup. The flume agent has a boot dependency on Hadoop and Yarn.

All servers in the cluster are configured to send their logs to rsyslog, which in turn ships the
logs to hadoop via Flume.

Elasticsearch Notes
-------------------

Elasticsearch is setup as a three node clsuter and listens on the 192.168.11.[x] adresses. Each node
in the hadoop cluster is also an elasticsearch cluster member. The master and data nodes are elected
automatically and each node is capable of becoming an elasticsearch master node.

The API can be access via port 9200. An example API call is:

curl -X GET 'http://192.168.11.51:9200'

This can also be ran from the master hadoop node.

Kibana Notes
------------

Kibana is setup on the master hadoop node. It is available on port 5601. Using the default IP
addresses above, the url would be:

http://192.168.11.51:5601/

An index pattern has not been configured.


What's Missing
--------------

I didn't have time to write a mapreduce job to index data from hadoop into elasticsearch or to
archive data from elasticsearch into hadoop. Because of this I was not able to map the elasticsearch
data into Kibana and provide visualizations.