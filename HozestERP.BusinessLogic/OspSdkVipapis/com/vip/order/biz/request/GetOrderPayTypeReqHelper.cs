using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrderPayTypeReqHelper : TBeanSerializer<GetOrderPayTypeReq>
	{
		
		public static GetOrderPayTypeReqHelper OBJ = new GetOrderPayTypeReqHelper();
		
		public static GetOrderPayTypeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderPayTypeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnSet".Equals(schemeField.Trim())){
						
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
						
						structs.SetOrderSnSet(value);
					}
					
					
					
					
					
					if ("sourceSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								int elem2;
								elem2 = iprot.ReadI32(); 
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetSourceSet(value);
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
		
		
		public void Write(GetOrderPayTypeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnSet() != null) {
				
				oprot.WriteFieldBegin("orderSnSet");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetOrderSnSet()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceSet() != null) {
				
				oprot.WriteFieldBegin("sourceSet");
				
				oprot.WriteSetBegin();
				foreach(int _item0 in structs.GetSourceSet()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderPayTypeReq bean){
			
			
		}
		
	}
	
}