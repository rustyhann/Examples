Project Proposal (In Progress)
===============================================================================

Analyzing Log Data with Hadoop and the ELK Stack
-------------------------------------------------------------------------------

This project aims to build a syslog analysis stack using Hadoop,
Elastic Search, Kibana, and Logstash. 

After creating a basic web application using the LEMP stack, syslog events will 
be generated for the website and system as a whole using batch scripts. These 
logs will be streamed into an HDFS file sytem to be analyzed and visualized 
using Hadoop technologies and the ELK stack. The goal of this proejct is to build 
a system which can efficiently and accurately analyze and visualize large
amounts of log data.

Team
-------------------------------------------------------------------------------

  * Rusty Hann, rehann, rehann, rehann (Lead)

Role
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

* All: Rusty Hann

Artifacts
-------------------------------------------------------------------------------

* Put here a list of artifacts that you will create (this can be 
  filled out at a later time)

List of Technologies
-------------------------------------------------------------------------------

Development Languages
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

* Python
* Ansible
* Pig
* Bash
* Django
* Map/Reduce
* SQL
* Java

Software Tools
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

* Ansible
* Apache / nGinx / MariaDB -> Client systems
* Hadoop (HDFS) - Long term log storage
* Pig - Offload data to HDFS
* Elastic Search - The awesome
* LogStash - will most likely go with Flume
* Kibana - Visualization
* Flume - Log collection which feeds into multiple ElasticSearch sinks

Compute Resources
-------------------------------------------------------------------------------

* OpenStack in FutureSystems

System Requirements
-------------------------------------------------------------------------------

* Size: 10 VM instances
* OS: Debian 7.0 Wheezy
* Storage: 100 GB total, 10 VM Instances at 10GB each

List of DataSets
-------------------------------------------------------------------------------

* Data will be generated through scripts which automate normal system tasks.

Schedule
-------------------------------------------------------------------------------

* Week 1: Initial Meeting
* Week 2: Proposal
* Week 3: Discussion
* Week 4: Presentation
* Week 5: Refine raw dataset
* Week 6: Build systems
* Week 7: Develop modules, test run
* Week 8: Final Report, Review, Submission

Project Style and Type
-------------------------------------------------------------------------------

* Bonus
* Deployment

Acknowledgement
-------------------------------------------------------------------------------

This project idea is obtained from the following sources:

* http://hortonworks.com/hadoop-tutorial/how-to-refine-and-visualize-server-log-data/
* https://www.elastic.co/webinars/introduction-elk-stack
* http://www.slideshare.net/hortonworks/hortonworks-elastic-searchfinal
* https://blog.treasuredata.com/blog/2015/08/31/hadoop-vs-elasticsearch-for-advanced-analytics/
* https://www.mapr.com/apps/elasticsearch-apache-hadoop
* http://www.bigdatalittlegeek.com/blog/2014/4/16/logging-architectures-and-elasticsearch-elk
* https://www.elastic.co/products/hadoop
* http://hortonworks.com/blog/configure-elastic-search-hadoop-hdp-2-0/
* https://github.com/analytically/hadoop-ansible
* https://github.com/NFLabs/ansible-hadoop
