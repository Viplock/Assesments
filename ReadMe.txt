******************************************************************************
*	Created By : Vipul Pratap Singh                                              *
*	Contact    : vipul-pratap.singh@atos.net                                     *
******************************************************************************
# Patient Api
	This is a Web API application for lab test data handing and reporting developed using .Net Core 5.0

# Problem statement
	Need application that is capable of
	1. Generate authentication token for security access
	2. Creating/Managing Patient 
	3. Creating/Managing Test
	4. Creating/Managing/Reporting Test Reports 

# Tables (As model classes for In-Memory DB implementation)
	UserCreds
		string UserName//Logged in user name
		string PassKey//User password
		
	Patient
        	int PatientId//PrimarKey

		string PName //Patient Name
		DateTime DOB //Date of birth of patient
        Enum Gender PGender //Gender of patient (0 - Male, 1 - Female, 2 - Other)
		string ContactNumber //Patient contact number
		
	Demo records are at Patient.json file


	LabTest
		int LabReportId//PrimarKey
		string ReportType //Type of test
		string Result //Resulted points of the test
		DateTime TimeOfTest //Minimum limit of value for the result
		DateTime EnteredTime //Maximum limit of value for the result
		int PatientId //To mark for soft delete
		string ReportCenterName //from where the test is done
	
	Demo records are at LabTests.json file	
	
# Approach
	Implemention using In-Memory DB
	User credentials in UserCreds class (Using JWT token)
	Patient details in Patient class
	Test details in LabTest class
	
	
#Operations Supported with endpoints
	Operations supported with endpoint details, sample URL and payload information 
	
	1. Endpoint Login/Authentication
		* Authentication : (Post : https://localhost:44396/api/Authentication)
			{
				"username": "Vipul",
				"password": "P@ssword"
			}


// { "Vipul", "P@ssword" }, { "Pratap", "P@ssKey" }  // demo login password

			
	2. Endpoint Patient
		* Create/POST : (Post : https://localhost:44396/api/Patient)
			{
			  "patientId": 0,
			  "pName": "Test Name",
			  "dob": "1990-10-18T13:24:31.865Z",
			  "pGender": 0,
			  "contactNumber": "987766559"
			}
		* Update : (Put : https://localhost:44396/api/Patient/1)
			{
			  "patientId": 0,
			  "pName": "Test Name Updated",
			  "dob": "1990-10-18T13:24:31.865Z",
			  "pGender": 0,
			  "contactNumber": "987766559"
			}
		* Delete : (Delete : https://localhost:44396/api/Patient/1)
		* GetAll : (Get : https://localhost:44396/api/Patient)
		* GetById : (Get : https://localhost:44396/api/Patient/1)
		
		* Filtered Data :(Post : https://localhost:44396/api/Patient/filter)
						{
						  "reportType": "blood test",
						  "fromdate": "2019-10-18T13:32:27.067Z",
						  "toDate": "2021-10-18T13:32:27.067Z"
						}
		
		//Getting filtered data on the bases of report type and date range
		
	3. Endpoint LabReport
		* Create : (Post : https://localhost:44396/api/LabReport)
			{
			  "labReportId": 0,
			  "reportType": "Blood Test",
			  "result": "Looks Good",
			  "timeOfTest": "2021-10-18T13:43:21.080Z",
			  "enteredTime": "2021-10-18T13:43:21.080Z",
			  "patientId": 0,
			  "reportCenterName": "Pune Lab"
			}
					
		* Update : (Put : https://localhost:44396/api/LabReport/5)
			{
			  "labReportId": 0,
			  "reportType": "Blood Test",
			  "result": "Looks Good Update",
			  "timeOfTest": "2021-10-18T13:43:21.080Z",
			  "enteredTime": "2021-10-18T13:43:21.080Z",
			  "patientId": 0,
			  "reportCenterName": "Pune Lab"
			}		
		* Delete : (Delete : https://localhost:44396/api/LabReport/5)
		* GetAll : (Get : https://localhost:44396/api/LabReport)
		* GetById : (Get : https://localhost:44367/LabTest/Get/1)
	
		
#Installation
	1. Copy code in a folder
	2. Open PatientDigitalApi soultion using Microsoft Visual Studio (PatientDigitalApi.sln)
	3. Build and Run project PatientDigitalApi
	4. Application should run in browser using Swagger UI
	5. Postman can also be configured (as per above url and payload details) for generating and passing token
	
#Steps to run with Swagger
	1. Execute endpoint Authorization (Credentials as in Login endpoint details above) to generate token
	2. Once token is generated, copy the generated token
	3. Click Authorize button in page header to open "Provide Token" dialogue
	4. Enter only token in the text input under value
	5. click Authorize and then Close button
	6. Now you are ready to run, follow sequence as below to handle data dependencies 
	7. GetAll LabReport (if executed Get(), will return all the lab reports)

#Steps to run with Postman
	1. Configure Postman requests as per information above
	2. Execute Authorization (Credentials as above) to generate token
	3. Once token is generated, copy the generated token to pass with subsequet requests
	4. Follow sequence as below to handle data dependencies 
	5. GetAll LabReport (if executed Get(), will return all the lab reports)
