                                 
                                    Vend QA Engineer Test

Requirement
-------------------
>Please refer to another document named as 'QA Engineer Test.pdf'.

>According to the requirement, I will change the manager's 'Promotion' 
 permission and test whether it can be enforced in the web application.

Demo
----------------------
>Please refer to the 'Demo.mp4' from Email.

Test framework and automation design pattern
-------------------------------------------------
>Framework:DD (Data Driven)
>Design pattern: POM(Page Object Model)
>IDE: Visual Studio based on .NET framework 4.5.2
>>Test environment structure 
>>>1. 'Config' folder (to store the configurations and parameters)
>>>2. 'Global' folder (to store the public variables, common methods,
       initialization and API related functions)
>>>3. 'Page' folder (to store all the page class)
>>>4. 'Test' folder (to store the test cases)

Test tools
--------------
>1. API
>>  Newtonsoft.Json
>>  Restsharp
>2. UI
>>  Selenium
>>  Nunit

Test workflow
--------------------
>Please see another document named as 'Test workflow' from Email.

Test progress
------------------
>Test enviroment and test cases: done
>Test result:pass

Issues and problems
----------------------------
> I created four trial accounts (nancyfruit, nancylu, morgan and human), 
  but only 'morgan' had the right status code when its token communicating
  with server; while the other three accounts displayed 'Unauthorized' and 
  the return body was null. So I can only use Shop 'Morgan'.

> When I tried to do CLICK action on "Products" element under 'webregister'
  page, it cannot forward to correct page; then I tried Javascript executor to 
  simulate the CLICK operation on 'Products' element, although forwarding 
  was correct, some unexpected errors returned; so I had to navigate it directly
  to Products/Promotions.





