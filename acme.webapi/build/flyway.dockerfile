FROM ubuntu:latest

# Declare the environment variables

ENV HOST dockerhost
ENV DB acme
ENV USER sa
ENV PASSWORD MySuperSecret@dev478

WORKDIR /install

# Update the package manager
RUN apt-get update
RUN apt-get install wget iproute2 -y

# Download flyway
RUN wget -O flyway.tar.gz https://repo1.maven.org/maven2/org/flywaydb/flyway-commandline/7.5.4/flyway-commandline-7.5.4-linux-x64.tar.gz 

# Extract it
RUN tar -xf flyway.tar.gz -C /
RUN mv /flyway* /flyway

WORKDIR /

# Remove the archive
RUN rm -rf /install

RUN echo #!bin/bash >> /bin/migrate.sh
RUN echo '/flyway/flyway -locations=filesystem:/flyway/sql -user=${USER} -password=${PASSWORD} migrate' >> /bin/migrate.sh
RUN chmod +x /bin/migrate.sh

RUN echo #!bin/bash >> /bin/clean.sh
RUN echo '/flyway/flyway -locations=filesystem:/flyway/sql -user=${USER} -password=${PASSWORD} clean' >> /bin/clean.sh
RUN chmod +x /bin/clean.sh

CMD ["/bin/bash"]
