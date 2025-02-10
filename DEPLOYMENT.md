In your project folder, run:
touch DEPLOYMENT.md

***

- Add Deployment Instructions
  Deploying the Website to AWS

1️⃣ Hosting the Website on AWS
This guide will help you deploy a PHP-based dynamic website to AWS.

AWS Services Used:
- S3 – For storing static files.
- EC2 (Ubuntu) – Hosting the PHP backend.
- RDS (MySQL) – Database for dynamic content.

2️⃣ Setting Up the AWS EC2 Server

Connect to EC2 Instance

ssh -i your-key.pem ubuntu@your-ec2-instance-ip

***

- Install Apache and PHP
sudo apt update
sudo apt install apache2 php libapache2-mod-php php-mysql

***

- Start and Enable Apache

sudo systemctl start apache2
sudo systemctl enable apache2

***

- Upload Project Files
cd /var/www/html
sudo git clone https://github.com/YOUR_USERNAME/dynamic-website.git

***

- Restart Apache
sudo systemctl restart apache2

*** 

- Configure RDS Database
<?php
$host = "your-rds-endpoint";
$dbname = "your-database";
$user = "your-username";
$pass = "your-password";
$conn = new mysqli($host, $user, $pass, $dbname);
?>

***

- Final Deployment Steps
cd /var/www/html/dynamic-website
git pull origin main
