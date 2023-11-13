
# .NET Microservice Architecture with RabbitMQ and Docker Compose

This repository contains a .NET-based microservice architecture leveraging RabbitMQ as the messaging broker, a relational database, and Docker Compose for easy local setup.



## SCOPE

• Building two .NET Microservices using the REST API pattern
• Working with dedicated persistence layers for both services
• Deploying our services to Kubernetes cluster
• Employing the API Gateway pattern to route to our services
• Building Synchronous messaging between services (HTTP)
• Building Asynchronous messaging between services using an Event Bus (RabbitMQ)


## Installation

- git clone https://github.com/yourusername/your-repo.git

- Navigate to the project directory.

  cd K8S

- Run the following command to start the services using Docker Compose.

kubectl apply -f platforms-depl.yaml
kubectl apply -f platforms-np-depl.yaml
kubectl apply -f commands-depl.yaml

This command will spin up the entire microservice architecture, including RabbitMQ and the database, allowing you to interact with the services locally.
