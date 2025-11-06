pipeline {
    agent any
    parameters {
        string(name: 'TEST_TAG', defaultValue: 'QA', description: 'Run tests with tag')
    }
    stages {
        stage('Check PATH') {
            steps {
                sh 'echo "PATH: $PATH"'
                sh 'which dotnet || echo "dotnet not found"'
                sh 'which allure || echo "allure not found"'
            }
        }
        stage('Clean') {
            steps {
                cleanWs()
            }
        }
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Load Config') {
            steps {
                withCredentials([file(credentialsId: 'appsettings-json', variable: 'CONFIG_FILE')]) {
                    script {
                        sh """
                        cp "\$CONFIG_FILE" "${WORKSPACE}/DemoBlaze/appsettings.json"
                        """
                        sh """
                        if [ -f "${WORKSPACE}/DemoBlaze/appsettings.json" ]; then
                            echo "Config file copied successfully"
                        else
                            echo "Config file not found"
                            exit 1
                        fi
                        """
                    }
                }
            }
        }
        stage('Restore') {
            steps {
                sh 'export PATH=$PATH:/usr/local/share/dotnet:/opt/homebrew/bin && dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'export PATH=$PATH:/usr/local/share/dotnet:/opt/homebrew/bin && dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                script {
                    catchError(buildResult: 'SUCCESS', stageResult: 'UNSTABLE') {
                        sh """
                        export PATH=\$PATH:/usr/local/share/dotnet:/opt/homebrew/bin
                        mkdir -p "${WORKSPACE}/Jefit_test/bin/Debug/net8.0/allure-results"
                        dotnet test --filter "Category=${params.TEST_TAG}" \
                            --logger "trx;LogFileName=${WORKSPACE}/TestResults/test-results.trx" \
                            --logger "allure;LogFilePath=${WORKSPACE}/Jefit_test/bin/Debug/net8.0/allure-results"
                        """
                    }
                }
            }
        }
    }
    post {
        always {
            script {
                def allureResultsDir = "${WORKSPACE}/Jefit_test/bin/Debug/net8.0/allure-results"
                if (fileExists(allureResultsDir)) {
                    echo "Allure results found! Generating report..."
                    sh """
                    export PATH="/opt/homebrew/bin:\$PATH"
                    which allure
                    allure --version
                    allure generate "${allureResultsDir}" --output "${WORKSPACE}/allure-report" --clean
                    """
                    archiveArtifacts artifacts: 'TestResults/*.trx, allure-report/**', allowEmptyArchive: true
                    allure includeProperties: false, 
                           jdk: '', 
                           results: [[path: 'Jefit_test/bin/Debug/net8.0/allure-results']]
                } else {
                    echo "Warning: Allure results directory not found at ${allureResultsDir}!"
                }
            }
        }
        success {
            echo 'SUCCESS!!!'
        }
    }
}