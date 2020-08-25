using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class OffShelfProductHelper : TBeanSerializer<OffShelfProduct>
	{
		
		public static OffShelfProductHelper OBJ = new OffShelfProductHelper();
		
		public static OffShelfProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OffShelfProduct structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_ids".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetSpu_ids(value);
					}
					
					
					
					
					
					if ("off_shelf_reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOff_shelf_reason(value);
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
		
		
		public void Write(OffShelfProduct structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_ids() != null) {
				
				oprot.WriteFieldBegin("spu_ids");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetSpu_ids()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_ids can not be null!");
			}
			
			
			if(structs.GetOff_shelf_reason() != null) {
				
				oprot.WriteFieldBegin("off_shelf_reason");
				oprot.WriteI32((int)structs.GetOff_shelf_reason()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("off_shelf_reason can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OffShelfProduct bean){
			
			
		}
		
	}
	
}