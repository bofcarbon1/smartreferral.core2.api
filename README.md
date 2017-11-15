# smartreferral.core2.api
A .Net Core 2.0 Api that provides data services with Entity Framework Core 2.0 for a SQL Server database

Application Details:

SmartReferralCore2Api

SmartReferralCore2Api handles all service requests for data utilizing .NET 2.0 Web API with Entity Framework Core 2.0 
against a SQL Server database. 

Application Prerequisites

  •	Setup SmartReferral database  
    o	SQL Server Management Studio 2014
      	Tables
        •	Candidate
    o	Candidate details
        •	Skill
    o	IT skills
        •	CandidateSkill
    o	Candidate skills and levels
    
## Key Features

The main purpose of SmarReferralCor2Api is to handle request for data in the SmartReferral database. 
This includes the following

  •	Get, add, modify and delete candidates
  •	Get, add, modify or delete skills
  •	Get, add, modify or delete candidate skills
  
## Application Modules

    Controllers
      Handle Http requests with json responses
      CandidateController
        Calls methods in CandidateEFRepository
    	SkillController
      	Calls methods in SkillEFRepository
    	CandidateSkillController
      	Calls methods in CandidateSkillEFRepository 
  	Interfaces
    	ICandidateRepository
    	ISkillRepository
    	ICandidateSkillRepository
  	Models
    	Candidate
    	Skill
    	CandidateSkill
  	EFHelpers
    	SmartReferralContext
      	Entity Framework context mappings to class models
    	CandidateEFRepository
      	Handle all data extracts and modifications for candidate data 
    	SkillEFRepository
      	Handle all data extracts and modifications for skills
    	CandidateSkillEFRepository
      	Handle all data extracts and modifications for candidate skills
 
  
   
