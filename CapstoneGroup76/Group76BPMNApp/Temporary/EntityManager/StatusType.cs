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

public class StatusType : BaseEntity {


	public StatusType() {
	}

	public override int getIdEnt() {
		return 10004;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("c9fe7b4f-6d7a-44a5-a4a9-b4602d8757a2") ;
	}

	public override String getEntityName() {
		return  "StatusType";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.StatusType";
   }

	String surrogateKey = "idStatusType";

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

    static Dictionary<string, Func<StatusType, object>> gets = new Dictionary<string, Func<StatusType, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<StatusType, object>((StatusType be) => be.getId() ) },
        { "Unsolved", new Func<StatusType, object>((StatusType be) => be.getUnsolved() )         },
        { "Pending", new Func<StatusType, object>((StatusType be) => be.getPending() )         },
        { "Solved", new Func<StatusType, object>((StatusType be) => be.getSolved() )         }    };

    static Dictionary<string, Action<StatusType,object>> sets = new Dictionary<string, Action<StatusType,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<StatusType,object>((StatusType be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "Unsolved", new Action<StatusType, object>((StatusType be, object newValue) => { if(newValue==null)be.setUnsolved(null); else be.setUnsolved(Convert.ToBoolean(newValue)); })         },
        { "Pending", new Action<StatusType, object>((StatusType be, object newValue) => { if(newValue==null)be.setPending(null); else be.setPending(Convert.ToBoolean(newValue)); })         },
        { "Solved", new Action<StatusType, object>((StatusType be, object newValue) => { if(newValue==null)be.setSolved(null); else be.setSolved(Convert.ToBoolean(newValue)); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return getUnsolved() != null ? getUnsolved().ToString() : null;
	}

	int? m_entityType = new int?(2);

	public override int? getEntityType()  {
		return m_entityType;
	}

	bool? m_Unsolved ;

	public bool? getUnsolved() {
		return m_Unsolved;
	}

	public void setUnsolved(bool? paramUnsolved){
		this.m_Unsolved = paramUnsolved;
	}

	bool? m_Pending ;

	public bool? getPending() {
		return m_Pending;
	}

	public void setPending(bool? paramPending){
		this.m_Pending = paramPending;
	}

	bool? m_Solved ;

	public bool? getSolved() {
		return m_Solved;
	}

	public void setSolved(bool? paramSolved){
		this.m_Solved = paramSolved;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "StatusType")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "StatusType";      
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

    StatusType tg = (StatusType) target; 
    cloneBaseValues(tg);
    tg.m_Unsolved = this.m_Unsolved; 
    tg.m_Pending = this.m_Pending; 
    tg.m_Solved = this.m_Solved; 

}

 
	}

}