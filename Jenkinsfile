pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Restore & Build') {
            steps {
                sh 'dotnet restore ORM1.csproj'
                sh 'dotnet build ORM1.csproj --no-restore'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test ORM1.Tests/ORM1.Tests.csproj --logger "trx;LogFileName=test-results.trx"'
            }
        }
    }
    post {
        always {
            mstest testResultsFile: '**/test-results.trx'
        }
    }
}
