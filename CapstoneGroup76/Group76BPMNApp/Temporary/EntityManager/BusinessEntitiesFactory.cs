namespace BizAgi.EntityManager.Entities { 
    using System; 

    using BizAgi.PAL; 

    class BusinessEntitiesFactory : IBEClassFactory {
        public IBaseEntity CreateBaseEntityInstance(string className) { 

            int lastDot = className.LastIndexOf('.'); 

            className = (lastDot != -1)? className.Substring(lastDot+1) : className ; 

            switch(className){

            case "WFUSER":
                return new WFUSER();
            case "LOCATION":
                return new LOCATION();
            case "AREA":
                return new AREA();
            case "ROLE":
                return new ROLE();
            case "SKILL":
                return new SKILL();
            case "ORGPOSITION":
                return new ORGPOSITION();
            case "WORKINGTIMESCHEMA":
                return new WORKINGTIMESCHEMA();
            case "ORG":
                return new ORG();
            case "BATIMEZONE":
                return new BATIMEZONE();
            case "LANGUAGE":
                return new LANGUAGE();
            case "USERSTARTPAGE":
                return new USERSTARTPAGE();
            case "App":
                return new App();
            case "ToBeModel":
                return new ToBeModel();
            case "Client":
                return new Client();
            case "StatusType":
                return new StatusType();
            case "Employee":
                return new Employee();
            case "Resolution":
                return new Resolution();
            }

            throw new Exception("Class not found." + className); 


        }

    }
}
