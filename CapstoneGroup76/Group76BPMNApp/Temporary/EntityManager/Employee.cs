namespace BizAgi.EntityManager.Entities {

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vision.Defs.OracleSpecific;
using BizAgi.PAL;
using BizAgi.PAL.Util;
using BizAgi.PAL.BeanUtils;
using BizAgi.EntityManager.Persistence;
using BizAgi.PAL.historylog;
using BizAgi.Resources;

public class Employee : BaseEntity {


	public Employee() {
	}

	public override int getIdEnt() {
		return 10005;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("571e53a8-0912-43e4-9d0f-c4f6334fbc53") ;
	}

	public override String getEntityName() {
		return  "Employee";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.Employee";
   }

	String surrogateKey = "idEmployee";

	public override String getSurrogateKey() {
		return surrogateKey;
	}

	public override bool isVirtualEntity() {
		return false;
	}

	public override Dictionary<string, object> getVirtualBusinessKey() {
		return new Dictionary<string, object>() {  };
	}

	public override bool canCreateNewInstances() {
		return true;
	}

    static Dictionary<string, Func<Employee, object>> gets = new Dictionary<string, Func<Employee, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<Employee, object>((Employee be) => be.getId() ) },
        { "EmployeeID", new Func<Employee, object>((Employee be) => be.getEmployeeID() )         },
        { "EmployeeName", new Func<Employee, object>((Employee be) => be.getEmployeeName() )         },
        { "EmployeeLevel", new Func<Employee, object>((Employee be) => be.getEmployeeLevel() )         }    };

    static Dictionary<string, Action<Employee,object>> sets = new Dictionary<string, Action<Employee,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<Employee,object>((Employee be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "EmployeeID", new Action<Employee, object>((Employee be, object newValue) => { if(newValue==null)be.setEmployeeID(null); else be.setEmployeeID((string) newValue ); })         },
        { "EmployeeName", new Action<Employee, object>((Employee be, object newValue) => { if(newValue==null)be.setEmployeeName(null); else be.setEmployeeName((string) newValue ); })         },
        { "EmployeeLevel", new Action<Employee, object>((Employee be, object newValue) => { if(newValue==null)be.setEmployeeLevel(null); else be.setEmployeeLevel((string) newValue ); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	string m_EmployeeID ;

	public string getEmployeeID() {
		return m_EmployeeID;
	}

	public void setEmployeeID(string paramEmployeeID){
		this.m_EmployeeID = paramEmployeeID;
	}

	string m_EmployeeName ;

	public string getEmployeeName() {
		return m_EmployeeName;
	}

	public void setEmployeeName(string paramEmployeeName){
		this.m_EmployeeName = paramEmployeeName;
	}

	string m_EmployeeLevel ;

	public string getEmployeeLevel() {
		return m_EmployeeLevel;
	}

	public void setEmployeeLevel(string paramEmployeeLevel){
		this.m_EmployeeLevel = paramEmployeeLevel;
	}

   public override object getXPath(PropertyTokenizer xPathTokenizer) {
       String completeXPath = xPathTokenizer.getCurrentPath();
               return BizAgi.PAL.XPath.XPathUtil.evaluateXPath(this, completeXPath);
   }

    public override IBaseEntity addRelationWithId(String path, long id, bool createBackRelationScopeAction, bool createHistoryLogActions, bool isAttach = true) {
        try {
        BaseEntity ret = null;
        String attrRelated = null;
        bool bIsMxMFact = false;
  if(!gets.ContainsKey(path)){ return base.addRelationWithId(path, id, createBackRelationScopeAction, createHistoryLogActions, isAttach ); }  
 

        if (ret == null) {
            throw new BABeanUtilsException("Path not found. Path:" + path);
        } else {
            ret.setHistoryLog(getHistoryLog());
            ret.setPersistenceManager(getPersistenceManager());
            if (!bIsMxMFact) {
				if (createBackRelationScopeAction) {
					ret.setXPath(attrRelated, this);
				} else {
					PropertyUtils.setProperty(ret, attrRelated, this);
				}
            }
            return ret;
        }
        } catch (Exception e) {
           throw new BABeanUtilsException(e);
        }
    }

	public override IBaseEntity addRelation(String path, long id) {
		BaseEntity ret = (BaseEntity)addRelationWithId(path, id, true, true);
         ScopeAction action;
       if (getEntityType().Value == 0) {// PV Entity
           action = ScopeActionFactory.getAddRelationAction(ret.getId(), path);
       } else {
           action = ScopeActionFactory.getAddRelationEntityAction(this.getClassName(), this.getId(), ret.getId(), path);
       }
       getHistoryLog().add(action);
       return ret;
	}

	public override String toXML()  {
		StringBuilder xml = new StringBuilder();
		return xml.ToString();
	}
	public override Object getLocalizedValue(String attributeName) {
		Object attributeValue = this.getXPath(attributeName);		
		return attributeValue;
	}
	public override bool containsAttribute(string propertyName) {
		return gets.ContainsKey(propertyName); 
	}
	protected override Object GetPropertyValueByName(string propertyName) {
		if(gets.ContainsKey(propertyName)) 
		    return gets[propertyName].Invoke(this); 
		else if (this.GetType().BaseType != typeof(BaseEntity)) 
		    return base.GetPropertyValueByName(propertyName); 
		throw new Exception("Attribute not found"); 
	}
	public override void SetPropertyValue(string propertyName, object newValue) {
	    if(newValue == DBNull.Value) 
	        newValue = null; 
	    if(sets.ContainsKey(propertyName)){ 
	        sets[propertyName].Invoke(this, newValue); 
	        return; 
		}else if (this.GetType().BaseType != typeof(BaseEntity)){ 
	        base.SetPropertyValue(propertyName, newValue); return;  }
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "Employee")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "Employee";      
		else if (this.GetType().BaseType != typeof(BaseEntity))  
		   return base.GetFactOwnerEntityName(factName);      
		throw new Exception("Fact entity not found for '"+ factName + "' "); 
	}
	public override string GetFactOwnerAttribute(string factKey) {
		return _factToParentAttribute[factKey]; 
	}
	public override bool ExistsFactOwnerAttribute(string factKey) {
		return _factToParentAttribute.ContainsKey(factKey); 
	}
	protected override void  cloneValues(object target, Hashtable reentrance){

    Employee tg = (Employee) target; 
    cloneBaseValues(tg);
    tg.m_EmployeeID = this.m_EmployeeID; 
    tg.m_EmployeeName = this.m_EmployeeName; 
    tg.m_EmployeeLevel = this.m_EmployeeLevel; 

}

 
	}

}