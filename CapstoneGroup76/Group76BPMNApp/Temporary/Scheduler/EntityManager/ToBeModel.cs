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

public class ToBeModel : BaseEntity {


	public ToBeModel() {
	}

	public override int getIdEnt() {
		return 10002;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("11ac16d7-2c84-4157-a8a7-d779ffb39b83") ;
	}

	public override String getEntityName() {
		return  "ToBeModel";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.ToBeModel";
   }

	String surrogateKey = "idToBeModel";

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

    static Dictionary<string, Func<ToBeModel, object>> gets = new Dictionary<string, Func<ToBeModel, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<ToBeModel, object>((ToBeModel be) => be.getId() ) },
        { "RequestID", new Func<ToBeModel, object>((ToBeModel be) => be.getRequestID() )         },
        { "RequestDescription", new Func<ToBeModel, object>((ToBeModel be) => be.getRequestDescription() )         },
        { "Status", new Func<ToBeModel, object>((ToBeModel be) => be.getStatus() )         },
        { "PriorityLevel", new Func<ToBeModel, object>((ToBeModel be) => be.getPriorityLevel() )         },
        { "DateOfRequest", new Func<ToBeModel, object>((ToBeModel be) => be.getDateOfRequest() )         },
        { "ClientID", new Func<ToBeModel, object>((ToBeModel be) => be.getClientID() )         },
        { "EmployeeID", new Func<ToBeModel, object>((ToBeModel be) => be.getEmployeeID() )         }    };

    static Dictionary<string, Action<ToBeModel,object>> sets = new Dictionary<string, Action<ToBeModel,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<ToBeModel,object>((ToBeModel be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "RequestID", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setRequestID(null); else be.setRequestID(Convert.ToInt32(newValue)); })         },
        { "RequestDescription", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setRequestDescription(null); else be.setRequestDescription((string) newValue ); })         },
        { "Status", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setStatus(null); else be.setStatus((StatusType) newValue ); })         },
        { "PriorityLevel", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setPriorityLevel(null); else be.setPriorityLevel(Convert.ToBoolean(newValue)); })         },
        { "DateOfRequest", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setDateOfRequest(null); else be.setDateOfRequest(Convert.ToDateTime(newValue)); })         },
        { "ClientID", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setClientID(null); else be.setClientID((Client) newValue ); })         },
        { "EmployeeID", new Action<ToBeModel, object>((ToBeModel be, object newValue) => { if(newValue==null)be.setEmployeeID(null); else be.setEmployeeID((Employee) newValue ); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	int? m_RequestID ;

	public int? getRequestID() {
		return m_RequestID;
	}

	public void setRequestID(int? paramRequestID){
		this.m_RequestID = paramRequestID;
	}

	string m_RequestDescription ;

	public string getRequestDescription() {
		return m_RequestDescription;
	}

	public void setRequestDescription(string paramRequestDescription){
		this.m_RequestDescription = paramRequestDescription;
	}

	StatusType m_Status ;

	public StatusType getStatus() {
		if ((!this.isPersisting()) && (m_Status != null) ) { 
			m_Status = (StatusType)getPersistenceManager().find(m_Status.getClassName(), m_Status.getId());
		}
		return m_Status;
	}

	public void setStatus(StatusType paramStatus){
		this.m_Status = paramStatus;
	}

	bool? m_PriorityLevel ;

	public bool? getPriorityLevel() {
		return m_PriorityLevel;
	}

	public void setPriorityLevel(bool? paramPriorityLevel){
		this.m_PriorityLevel = paramPriorityLevel;
	}

	DateTime? m_DateOfRequest ;

	public DateTime? getDateOfRequest() {
		return m_DateOfRequest;
	}

	public void setDateOfRequest(DateTime? paramDateOfRequest){
		this.m_DateOfRequest = paramDateOfRequest;
	}

	Client m_ClientID ;

	public Client getClientID() {
        if ((!this.isPersisting()) && (m_ClientID != null) && (m_ClientID.isLoaded() ) ) { 
            m_ClientID = (Client)getPersistenceManager().find(m_ClientID.getClassName(), m_ClientID.getId());
        } else if ((!this.isPersisting()) && (m_ClientID != null)) { 
            m_ClientID = (Client)ApplyScopeChangesToEntity(m_ClientID);
        }
		return m_ClientID;
	}

	public void setClientID(Client paramClientID){
		this.m_ClientID = paramClientID;
	}

	Employee m_EmployeeID ;

	public Employee getEmployeeID() {
        if ((!this.isPersisting()) && (m_EmployeeID != null) && (m_EmployeeID.isLoaded() ) ) { 
            m_EmployeeID = (Employee)getPersistenceManager().find(m_EmployeeID.getClassName(), m_EmployeeID.getId());
        } else if ((!this.isPersisting()) && (m_EmployeeID != null)) { 
            m_EmployeeID = (Employee)ApplyScopeChangesToEntity(m_EmployeeID);
        }
		return m_EmployeeID;
	}

	public void setEmployeeID(Employee paramEmployeeID){
		this.m_EmployeeID = paramEmployeeID;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "ToBeModel")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "ToBeModel";      
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

    ToBeModel tg = (ToBeModel) target; 
    cloneBaseValues(tg);
    tg.m_RequestID = this.m_RequestID; 
    tg.m_RequestDescription = this.m_RequestDescription; 
    tg.m_Status = (StatusType)cloneRelation(this.m_Status); 
    tg.m_PriorityLevel = this.m_PriorityLevel; 
    tg.m_DateOfRequest = this.m_DateOfRequest; 
    tg.m_ClientID = (Client)cloneRelation(this.m_ClientID); 
    tg.m_EmployeeID = (Employee)cloneRelation(this.m_EmployeeID); 

}

 
	}

}