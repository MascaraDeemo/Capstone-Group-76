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

public class Client : BaseEntity {


	public Client() {
	}

	public override int getIdEnt() {
		return 10003;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("a575e82a-1f7c-48ab-a900-77eccefb98bb") ;
	}

	public override String getEntityName() {
		return  "Client";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.Client";
   }

	String surrogateKey = "idClient";

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

    static Dictionary<string, Func<Client, object>> gets = new Dictionary<string, Func<Client, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<Client, object>((Client be) => be.getId() ) },
        { "ClientID", new Func<Client, object>((Client be) => be.getClientID() )         },
        { "ClientName", new Func<Client, object>((Client be) => be.getClientName() )         },
        { "EmailAddress", new Func<Client, object>((Client be) => be.getEmailAddress() )         }    };

    static Dictionary<string, Action<Client,object>> sets = new Dictionary<string, Action<Client,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<Client,object>((Client be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "ClientID", new Action<Client, object>((Client be, object newValue) => { if(newValue==null)be.setClientID(null); else be.setClientID(Convert.ToInt32(newValue)); })         },
        { "ClientName", new Action<Client, object>((Client be, object newValue) => { if(newValue==null)be.setClientName(null); else be.setClientName((string) newValue ); })         },
        { "EmailAddress", new Action<Client, object>((Client be, object newValue) => { if(newValue==null)be.setEmailAddress(null); else be.setEmailAddress((string) newValue ); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	int? m_ClientID ;

	public int? getClientID() {
		return m_ClientID;
	}

	public void setClientID(int? paramClientID){
		this.m_ClientID = paramClientID;
	}

	string m_ClientName ;

	public string getClientName() {
		return m_ClientName;
	}

	public void setClientName(string paramClientName){
		this.m_ClientName = paramClientName;
	}

	string m_EmailAddress ;

	public string getEmailAddress() {
		return m_EmailAddress;
	}

	public void setEmailAddress(string paramEmailAddress){
		this.m_EmailAddress = paramEmailAddress;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "Client")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "Client";      
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

    Client tg = (Client) target; 
    cloneBaseValues(tg);
    tg.m_ClientID = this.m_ClientID; 
    tg.m_ClientName = this.m_ClientName; 
    tg.m_EmailAddress = this.m_EmailAddress; 

}

 
	}

}