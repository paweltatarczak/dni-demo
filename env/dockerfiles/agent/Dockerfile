FROM mcr.microsoft.com/dotnet/sdk:5.0

LABEL maintainer="pawel t"

COPY agent.jar .

RUN mkdir -p /usr/share/man/man1 \
    #&& apt-get update -y && apt-get install openjdk-11-jdk git -y \
    && apt-get update -y && apt-get install openjdk-11-jdk git docker.io -y \
    && dotnet tool install --tool-path /usr/share/dotnet dotnet-sonarscanner \
    && ln -s /usr/share/dotnet/dotnet-sonarscanner /usr/bin/dotnet-sonarscanner

CMD ["java", "-jar" "/agent.jar"]
