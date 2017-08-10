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

public class Resolution : BaseEntity {


	public Resolution() {
	}

	public override int getIdEnt() {
		return 10006;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("f93441ba-0d3a-401f-bd67-15dcfbff43fa") ;
	}

	public override String getEntityName() {
		return  "Resolution";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.Resolution";
   }

	String surrogateKey = "idResolution";

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

    static Dictionary<string, Func<Resolution, object>> gets = new Dictionary<string, Func<Resolution, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<Resolution, object>((Resolution be) => be.getId() ) },
        { "ResolutionID", new Func<Resolution, object>((Resolution be) => be.getResolutionID() )         },
        { "EmployeeID", new Func<Resolution, object>((Resolution be) => be.getEmployeeID() )         },
        { "ResolutionContent", new Func<Resolution, object>((Resolution be) => be.getResolutionContent() )         }    };

    static Dictionary<string, Action<Resolution,object>> sets = new Dictionary<string, Action<Resolution,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<Resolution,object>((Resolution be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "ResolutionID", new Action<Resolution, object>((Resolution be, object newValue) => { if(newValue==null)be.setResolutionID(null); else be.setResolutionID((ToBeModel) newValue ); })         },
        { "EmployeeID", new Action<Resolution, object>((Resolution be, object newValue) => { if(newValue==null)be.setEmployeeID(null); else be.setEmployeeID((Employee) newValue ); })         },
        { "ResolutionContent", new Action<Resolution, object>((Resolution be, object newValue) => { if(newValue==null)be.setResolutionContent(null); else be.setResolutionContent((string) newValue ); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	ToBeModel m_ResolutionID ;

	public ToBeModel getResolutionID() {
        if ((!this.isPersisting()) && (m_ResolutionID != null) && (m_ResolutionID.isLoaded() ) ) { 
            m_ResolutionID = (ToBeModel)getPersistenceManager().find(m_ResolutionID.getClassName(), m_ResolutionID.getId());
        } else if ((!this.isPersisting()) && (m_ResolutionID != null)) { 
            m_ResolutionID = (ToBeModel)ApplyScopeChangesToEntity(m_ResolutionID);
        }
		return m_ResolutionID;
	}

	public void setResolutionID(ToBeModel paramResolutionID){
		this.m_ResolutionID = paramResolutionID;
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

	string m_ResolutionContent ;

	public string getResolutionContent() {
		return m_ResolutionContent;
	}

	public void setResolutionContent(string paramResolutionContent){
		this.m_ResolutionContent = paramResolutionContent;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "Resolution")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "Resolution";      
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

    Resolution tg = (Resolution) target; 
    cloneBaseValues(tg);
    tg.m_ResolutionID = (ToBeModel)cloneRelation(this.m_ResolutionID); 
    tg.m_EmployeeID = (Employee)cloneRelation(this.m_EmployeeID); 
    tg.m_ResolutionContent = this.m_ResolutionContent; 

}

 
	}

}