pipeline {
    agent {
        label 'dotnecik'
    }
    
    stages {
        stage('Clearing working app') {
            steps {
                sh 'docker rm -f aspnetcoreapp || true'
            }
        }
        stage('Get Code') {
            steps {
                checkout scm
            }
        }

        stage('SonarQube start') {
            steps {
                sh 'dotnet-sonarscanner begin /k:"dnidemo" /d:sonar.host.url="http://sonarqube:9000" /d:sonar.login="da3fd856521837b7e92531b1c1931e184e106ff8"'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build src/'
            }
        }
        stage('SonarQube end') {
            steps {
                sh 'dotnet-sonarscanner end /d:sonar.login="da3fd856521837b7e92531b1c1931e184e106ff8"'
            }
        }
        stage('List tests') {
            steps {
                sh 'dotnet test src/ -t'
            }
        }
        stage('Unit tests') {
            steps {
                sh 'dotnet test src/ --filter ClassName!~Selenium'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish src/ -o out'
            }
        }
        stage('Listing output') {
            steps {
                sh 'ls -la out'
            }
        }
        stage('Creating docker image') {
            steps {
                sh 'docker build -t aspnetcoreapp . -f testout/Dockerfile'
            }
        }
        stage('Start application') {
            steps {
                sh 'docker run -d --name aspnetcoreapp -p 0.0.0.0:5000:5000 -e ASPNETCORE_URLS=http://+:5000 -t aspnetcoreapp'
            }
        }
        stage('Selenium tests') {
            steps {
                sh 'dotnet test src/ --filter ClassName~Selenium'
            }
        }        
    }
    
    
    post {
        always {
            sh 'docker stop aspnetcoreapp'
            deleteDir()
        }
    }
    
}
