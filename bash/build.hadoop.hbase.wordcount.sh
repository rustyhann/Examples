#!/bin/bash
clear
echo "Action: Using set -e"
set -e
echo "Action: Success"
sleep 2
clear

#######################
# Step 1 - Fix Hadoop #
#######################
 
echo "Action: Stopping HBase"
echo ""
/root/software/hbase-0.94.7/bin/stop-hbase.sh
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Stopping Hadoop"
echo ""
/root/software/hadoop-1.1.2/bin/stop-all.sh
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Removing Hadoop files from /tmp"
rm -rf /tmp/hadoop*
echo "Action: Success"
sleep 2
clear

echo "Action: Removing HBase files from /tmp"
rm -rf /tmp/hbase*
echo "Action: Success"
sleep 2
clear

echo "Action: Removing summer files from /tmp"
rm -rf /tmp/summer
echo "Action: Success"
sleep 2
clear

echo "Action: Formatting the namenode"
echo ""
hadoop namenode -format
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Starting Hadoop"
echo ""
/root/software/hadoop-1.1.2/bin/start-all.sh
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Starting HBase"
echo ""
/root/software/hbase-0.94.7/bin/start-hbase.sh
echo ""
echo "Action: Success"
sleep 2
clear

###############################
# Step 2 - Fix the Assignment #
###############################

echo "Action: Removing old mrInput directory"
rm -rf /root/MoocHomeworks/HBaseWordCount/data/clueweb09/mrInput
echo "Action: Success"
sleep 2
clear

echo "Action: Creating new mrInput directory"
mkdir -p /root/MoocHomeworks/HBaseWordCount/data/clueweb09/mrInput
echo "Action: Success"
sleep 2
clear

echo "Action: Creating HBase Tables"
echo ""
hadoop jar \
    /root/software/hadoop-1.1.2/lib/cglHBaseMooc.jar \
        iu.pti.hbaseapp.clueweb09.TableCreatorClueWeb09
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Creating Input Metadata"
echo ""
hadoop jar \
    /root/software/hadoop-1.1.2/lib/cglHBaseMooc.jar \
        iu.pti.hbaseapp.clueweb09.Helpers create-mr-input \
        /root/MoocHomeworks/HBaseWordCount/data/clueweb09/files/ \
        /root/MoocHomeworks/HBaseWordCount/data/clueweb09/mrInput/ \
        1
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Copying Metadata to HDFS"
echo ""
hadoop dfs -copyFromLocal \
    /root/MoocHomeworks/HBaseWordCount/data/clueweb09/mrInput/ \
    /cw09LoadInput
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Loading Data into HBase"
echo ""
hadoop jar \
    /root/software/hadoop-1.1.2/lib/cglHBaseMooc.jar \
        iu.pti.hbaseapp.clueweb09.DataLoaderClueWeb09 \
        /cw09LoadInput
echo ""
echo "Action: Success"
sleep 2
clear

echo "Action: Verifying Data"
echo ""
hadoop jar \
    /root/software/hadoop-1.1.2/lib/cglHBaseMooc.jar \
        iu.pti.hbaseapp.HBaseTableReader \
        clueWeb09DataTable \
        details \
        string \
        string \
        string \
        string \
        1 \
    > /root/MoocHomeworks/HBaseWordCount/dataTable1.txt
echo ""
echo "Action: Success"
sleep 2
clear

echo "Script: hbase-wordcount-prereqs.sh"
echo "Script: Complete"
echo "Script: Successful"