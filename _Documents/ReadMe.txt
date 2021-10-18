# API Development Challenge: Lab Test
    This is a Web API application for lab test data handing and reporting developed using .Net Core 5.0

#Software requirements
	1. Windows OS (4G RAM,50 GB HD)
	2. Visual Studio 2019 (version 16.11.04 +)
	3. Microsoft .Net Framework 4.8.04084
	4. SDK 5.0.401 

#Installation steps
	1. Copy code in a local folder
	2. Open APIDevelopmentChallenge soultion using Microsoft Visual Studio 
	3. Build and Run project API.LabTests
	4. Application should run in browser using Swagger UI
	
#Steps to run with Swagger
	1. Execute endpoint Login (Credentials as in Login endpoint details above) to generate token
		"username": "se",
		"password": "se"
	2. Once token is generated, copy the generated token
	3. Click Authorize button in page header to open "Available Authorizations" 
	4. Enter 'Bearer' [space] and then token in the text input under value
	5. Click Authorize and then Close button
	6. Now you are ready to run, follow sequence as below to handle data dependencies 
	7. Create Patient (if executed Get(), will create hardcoded Patients from backed if Patient table is empty)
	8. Create LabTest (if executed Get(), will create hardcoded Tests from backed if LabTest table is empty)
	9. Create Report (if executed Get(), will create hardcoded Reports from if when Report table is empty)

