# Enviroment variables can be set here.

export JAVA_HOME=/usr

# Give Flume more memory and pre-allocate, enable remote monitoring via JMX
export JAVA_OPTS="-Xms100m -Xmx200m -Dcom.sun.management.jmxremote -Dcom.sun.management.jmxremote.port=54321 -Dcom.sun.management.jmxremote.authenticate=false -Dcom.sun.management.jmxremote.ssl=false"
