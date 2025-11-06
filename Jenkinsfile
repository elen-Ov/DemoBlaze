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
                        def destination = "${WORKSPACE}/DemoBlaze/appsettings.json"
                        sh '''
                            cp "$CONFIG_FILE" "''' + destination + '''"
                        '''
                        sh '''
                            if [ -f "''' + destination + '''" ]; then
                                echo "Config file copied successfully"
                            else
                                echo "Config file not found"
                                exit 1
                            fi
                        '''
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
                        mkdir -p TestResults
                        dotnet test --filter "Category=${params.TEST_TAG}" --logger "trx;LogFileName=TestResults/test-results.trx"
                        """
                    }
                }
            }
        }
    }
    post {
        always {
            script {
                if (fileExists('TestResults')) {
                    sh """
                    export PATH=$PATH:/opt/homebrew/bin
                    mkdir -p allure-report
                    allure generate TestResults --output allure-report --clean
                    """
                    archiveArtifacts artifacts: 'TestResults/*.trx, allure-report/**', allowEmptyArchive: true
                } else {
                    echo "Warning: TestResults directory not found!"
                }
            }
            sh 'echo "Post finished"'
        }
        success {
            echo 'SUCCESS!!!'
        }
    }
}