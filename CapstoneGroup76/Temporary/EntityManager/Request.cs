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

public class Request : BaseEntity {


	public Request() {
	}

	public override int getIdEnt() {
		return 10003;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("ae341165-7fce-400b-bbff-37671d50b6f5") ;
	}

	public override String getEntityName() {
		return  "Request";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.Request";
   }

	String surrogateKey = "idRequest";

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

    static Dictionary<string, Func<Request, object>> gets = new Dictionary<string, Func<Request, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<Request, object>((Request be) => be.getId() ) },
        { "RequestContent", new Func<Request, object>((Request be) => be.getRequestContent() )         },
        { "RequestID", new Func<Request, object>((Request be) => be.getRequestID() )         },
        { "RecieveDate", new Func<Request, object>((Request be) => be.getRecieveDate() )         },
        { "SolveDate", new Func<Request, object>((Request be) => be.getSolveDate() )         },
        { "Priority", new Func<Request, object>((Request be) => be.getPriority() )         },
        { "ResolutionID", new Func<Request, object>((Request be) => be.getResolutionID() )         },
        { "ResolutionContent", new Func<Request, object>((Request be) => be.getResolutionContent() )         },
        { "SystemUpdate", new Func<Request, object>((Request be) => be.getSystemUpdate() )         },
        { "DifficultyLevel", new Func<Request, object>((Request be) => be.getDifficultyLevel() )         },
        { "EmployeeID", new Func<Request, object>((Request be) => be.getEmployeeID() )         },
        { "EmployeeName", new Func<Request, object>((Request be) => be.getEmployeeName() )         },
        { "RequestStatus", new Func<Request, object>((Request be) => be.getRequestStatus() )         }    };

    static Dictionary<string, Action<Request,object>> sets = new Dictionary<string, Action<Request,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<Request,object>((Request be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "RequestContent", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setRequestContent(null); else be.setRequestContent((Client) newValue ); })         },
        { "RequestID", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setRequestID(null); else be.setRequestID(Convert.ToInt32(newValue)); })         },
        { "RecieveDate", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setRecieveDate(null); else be.setRecieveDate(Convert.ToDateTime(newValue)); })         },
        { "SolveDate", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setSolveDate(null); else be.setSolveDate(Convert.ToDateTime(newValue)); })         },
        { "Priority", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setPriority(null); else be.setPriority((PriorityLevel) newValue ); })         },
        { "ResolutionID", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setResolutionID(null); else be.setResolutionID(Convert.ToInt32(newValue)); })         },
        { "ResolutionContent", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setResolutionContent(null); else be.setResolutionContent((string) newValue ); })         },
        { "SystemUpdate", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setSystemUpdate(null); else be.setSystemUpdate(Convert.ToBoolean(newValue)); })         },
        { "DifficultyLevel", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setDifficultyLevel(null); else be.setDifficultyLevel((string) newValue ); })         },
        { "EmployeeID", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setEmployeeID(null); else be.setEmployeeID(Convert.ToInt32(newValue)); })         },
        { "EmployeeName", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setEmployeeName(null); else be.setEmployeeName((string) newValue ); })         },
        { "RequestStatus", new Action<Request, object>((Request be, object newValue) => { if(newValue==null)be.setRequestStatus(null); else be.setRequestStatus(Convert.ToBoolean(newValue)); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	Client m_RequestContent ;

	public Client getRequestContent() {
        if ((!this.isPersisting()) && (m_RequestContent != null) && (m_RequestContent.isLoaded() ) ) { 
            m_RequestContent = (Client)getPersistenceManager().find(m_RequestContent.getClassName(), m_RequestContent.getId());
        } else if ((!this.isPersisting()) && (m_RequestContent != null)) { 
            m_RequestContent = (Client)ApplyScopeChangesToEntity(m_RequestContent);
        }
		return m_RequestContent;
	}

	public void setRequestContent(Client paramRequestContent){
		this.m_RequestContent = paramRequestContent;
	}

	int? m_RequestID ;

	public int? getRequestID() {
		return m_RequestID;
	}

	public void setRequestID(int? paramRequestID){
		this.m_RequestID = paramRequestID;
	}

	DateTime? m_RecieveDate ;

	public DateTime? getRecieveDate() {
		return m_RecieveDate;
	}

	public void setRecieveDate(DateTime? paramRecieveDate){
		this.m_RecieveDate = paramRecieveDate;
	}

	DateTime? m_SolveDate ;

	public DateTime? getSolveDate() {
		return m_SolveDate;
	}

	public void setSolveDate(DateTime? paramSolveDate){
		this.m_SolveDate = paramSolveDate;
	}

	PriorityLevel m_Priority ;

	public PriorityLevel getPriority() {
        if ((!this.isPersisting()) && (m_Priority != null) && (m_Priority.isLoaded() ) ) { 
            m_Priority = (PriorityLevel)getPersistenceManager().find(m_Priority.getClassName(), m_Priority.getId());
        } else if ((!this.isPersisting()) && (m_Priority != null)) { 
            m_Priority = (PriorityLevel)ApplyScopeChangesToEntity(m_Priority);
        }
		return m_Priority;
	}

	public void setPriority(PriorityLevel paramPriority){
		this.m_Priority = paramPriority;
	}

	int? m_ResolutionID ;

	public int? getResolutionID() {
		return m_ResolutionID;
	}

	public void setResolutionID(int? paramResolutionID){
		this.m_ResolutionID = paramResolutionID;
	}

	string m_ResolutionContent ;

	public string getResolutionContent() {
		return m_ResolutionContent;
	}

	public void setResolutionContent(string paramResolutionContent){
		this.m_ResolutionContent = paramResolutionContent;
	}

	bool? m_SystemUpdate ;

	public bool? getSystemUpdate() {
		return m_SystemUpdate;
	}

	public void setSystemUpdate(bool? paramSystemUpdate){
		this.m_SystemUpdate = paramSystemUpdate;
	}

	string m_DifficultyLevel ;

	public string getDifficultyLevel() {
		return m_DifficultyLevel;
	}

	public void setDifficultyLevel(string paramDifficultyLevel){
		this.m_DifficultyLevel = paramDifficultyLevel;
	}

	int? m_EmployeeID ;

	public int? getEmployeeID() {
		return m_EmployeeID;
	}

	public void setEmployeeID(int? paramEmployeeID){
		this.m_EmployeeID = paramEmployeeID;
	}

	string m_EmployeeName ;

	public string getEmployeeName() {
		return m_EmployeeName;
	}

	public void setEmployeeName(string paramEmployeeName){
		this.m_EmployeeName = paramEmployeeName;
	}

	bool? m_RequestStatus ;

	public bool? getRequestStatus() {
		return m_RequestStatus;
	}

	public void setRequestStatus(bool? paramRequestStatus){
		this.m_RequestStatus = paramRequestStatus;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "Request")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "Request";      
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

    Request tg = (Request) target; 
    cloneBaseValues(tg);
    tg.m_RequestContent = (Client)cloneRelation(this.m_RequestContent); 
    tg.m_RequestID = this.m_RequestID; 
    tg.m_RecieveDate = this.m_RecieveDate; 
    tg.m_SolveDate = this.m_SolveDate; 
    tg.m_Priority = (PriorityLevel)cloneRelation(this.m_Priority); 
    tg.m_ResolutionID = this.m_ResolutionID; 
    tg.m_ResolutionContent = this.m_ResolutionContent; 
    tg.m_SystemUpdate = this.m_SystemUpdate; 
    tg.m_DifficultyLevel = this.m_DifficultyLevel; 
    tg.m_EmployeeID = this.m_EmployeeID; 
    tg.m_EmployeeName = this.m_EmployeeName; 
    tg.m_RequestStatus = this.m_RequestStatus; 

}

 
	}

}