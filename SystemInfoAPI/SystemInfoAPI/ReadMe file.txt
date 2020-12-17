Credentials for login:- 

Username = "TejasRajput"
Password = "TEJAS2604"



once user will click on start to launch the application 2 browser will load one with swagger and other one with Angular UI.

for "AuthenticationController" we don't have authorize attribute and using that POST endpoint user can generate a Token
to access "SystemInfoController" controller.


for UI user will land to login page and need to give below mentioned credentials 
Username = "TejasRajput"
Password = "TEJAS2604"


after successfully login user will redirect to home page there user select any item from drop down, once user select UI will update with details page
as for Home button we implemented CanActivate user need to pass token without login if user try to access home page user will redirect to login page

