using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class ImportInitialQuantityResultHelper : TBeanSerializer<ImportInitialQuantityResult>
	{
		
		public static ImportInitialQuantityResultHelper OBJ = new ImportInitialQuantityResultHelper();
		
		public static ImportInitialQuantityResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImportInitialQuantityResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("importInitialQuantityList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.ImportInitialQuantity> value;
						
						value = new List<vipapis.normal.ImportInitialQuantity>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.ImportInitialQuantity elem0;
								
								elem0 = new vipapis.normal.ImportInitialQuantity();
								vipapis.normal.ImportInitialQuantityHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImportInitialQuantityList(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(ImportInitialQuantityResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImportInitialQuantityList() != null) {
				
				oprot.WriteFieldBegin("importInitialQuantityList");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.ImportInitialQuantity _item0 in structs.GetImportInitialQuantityList()){
					
					
					vipapis.normal.ImportInitialQuantityHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImportInitialQuantityResult bean){
			
			
		}
		
	}
	
}