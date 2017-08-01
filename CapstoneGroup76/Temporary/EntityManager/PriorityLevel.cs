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

public class PriorityLevel : BaseEntity {


	public PriorityLevel() {
	}

	public override int getIdEnt() {
		return 10005;
	}

	public override Guid getGuidEnt() {
		return Guid.Parse("7450cee5-b13e-450c-be6d-ed1b26edf807") ;
	}

	public override String getEntityName() {
		return  "PriorityLevel";
	}
   public override String getClassName() {
      return "BizAgi.EntityManager.Entities.PriorityLevel";
   }

	String surrogateKey = "idPriorityLevel";

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

    static Dictionary<string, Func<PriorityLevel, object>> gets = new Dictionary<string, Func<PriorityLevel, object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Func<PriorityLevel, object>((PriorityLevel be) => be.getId() ) },
        { "CriticalR", new Func<PriorityLevel, object>((PriorityLevel be) => be.getCriticalR() )         },
        { "UrgentR", new Func<PriorityLevel, object>((PriorityLevel be) => be.getUrgentR() )         },
        { "NormalR", new Func<PriorityLevel, object>((PriorityLevel be) => be.getNormalR() )         }    };

    static Dictionary<string, Action<PriorityLevel,object>> sets = new Dictionary<string, Action<PriorityLevel,object>>(StringComparer.OrdinalIgnoreCase)    {{ "id", new Action<PriorityLevel,object>((PriorityLevel be, object newValue ) => be.setId( Convert.ToInt64(newValue) ) ) },
        { "CriticalR", new Action<PriorityLevel, object>((PriorityLevel be, object newValue) => { if(newValue==null)be.setCriticalR(null); else be.setCriticalR((string) newValue ); })         },
        { "UrgentR", new Action<PriorityLevel, object>((PriorityLevel be, object newValue) => { if(newValue==null)be.setUrgentR(null); else be.setUrgentR((string) newValue ); })         },
        { "NormalR", new Action<PriorityLevel, object>((PriorityLevel be, object newValue) => { if(newValue==null)be.setNormalR(null); else be.setNormalR((string) newValue ); })         }    };

    static Dictionary<string, string> _factToParentAttribute = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)    {
    };
	public String getDisplayAttrib() {
		return null;
	}

	int? m_entityType = new int?(1);

	public override int? getEntityType()  {
		return m_entityType;
	}

	string m_CriticalR ;

	public string getCriticalR() {
		return m_CriticalR;
	}

	public void setCriticalR(string paramCriticalR){
		this.m_CriticalR = paramCriticalR;
	}

	string m_UrgentR ;

	public string getUrgentR() {
		return m_UrgentR;
	}

	public void setUrgentR(string paramUrgentR){
		this.m_UrgentR = paramUrgentR;
	}

	string m_NormalR ;

	public string getNormalR() {
		return m_NormalR;
	}

	public void setNormalR(string paramNormalR){
		this.m_NormalR = paramNormalR;
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
		throw new Exception(string.Format("Error trying to set value for Attribute {0} in Entity {1}", propertyName, "PriorityLevel")); 
	}
	public override string GetFactOwnerEntityName(string factName) {
		if(gets.ContainsKey(factName))  
		   return "PriorityLevel";      
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

    PriorityLevel tg = (PriorityLevel) target; 
    cloneBaseValues(tg);
    tg.m_CriticalR = this.m_CriticalR; 
    tg.m_UrgentR = this.m_UrgentR; 
    tg.m_NormalR = this.m_NormalR; 

}

 
	}

}