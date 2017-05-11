#!/bin/bash

clear

echo ""
echo "Parsing Arguments" 
if [ $# -ne 3 ]; then
    echo 1>&2 Usage: [PageRank Inputs File Directory][Number of Urls][Number Of Iterations]
    echo "e.g. ./compileAndExecHadoopPageRank.sh PageRankDataGenerator/pagerank5000g50.input.0 5000 1"
    exit -1
fi


# We do not need to move to the hadoop bin directory because the hadoop command is in path
echo ""
echo "Cleaning HDFS"
hadoop dfs -rmr /user/summer/*

echo ""
echo "Creating DFS input directory"
hadoop dfs -mkdir input

echo ""
echo "Copying data to DFS input directory"
hadoop dfs -put $1 input

echo ""
echo "Ensuring build dependencies are present:"
echo "    autotools-dev"
echo "    autoconf"
echo "    build-essential"
echo "    libtool"
sudo apt-get install -y autotools-dev autoconf build-essential libtool

echo ""
echo "Clean java class and jar"
ant clean

echo ""
echo "Compiling source code with ant"
ant

if [ -f dist/HadoopPageRankMooc.jar ]
then
    echo ""
    echo "Source code compiled!"
else
    echo ""
    echo "There may be errors in your source code, please check the debug message."
    exit 255
fi

echo ""
echo "Moving to /root/MoocHomeworks/HadoopPageRank"
cd /root/MoocHomeworks/HadoopPageRank/

echo ""
echo "Executing HadoopPageRankMooc.jar"
hadoop jar dist/HadoopPageRankMooc.jar indiana.cgl.hadoop.pagerank.HadoopPageRank input output $2 $3

echo ""
echo "Erasing file system output folder if it exists"
rm -rf output

echo ""
echo "Copying DFS output to file system output folder"
hadoop dfs -get output .

echo "PageRank Finished execution, see output in file system folder output/."