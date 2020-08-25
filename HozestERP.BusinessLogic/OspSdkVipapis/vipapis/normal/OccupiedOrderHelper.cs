using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class OccupiedOrderHelper : TBeanSerializer<OccupiedOrder>
	{
		
		public static OccupiedOrderHelper OBJ = new OccupiedOrderHelper();
		
		public static OccupiedOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OccupiedOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("occupied_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOccupied_order_sn(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("barcodes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.OccupiedOrderDetail> value;
						
						value = new List<vipapis.normal.OccupiedOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.OccupiedOrderDetail elem0;
								
								elem0 = new vipapis.normal.OccupiedOrderDetail();
								vipapis.normal.OccupiedOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBarcodes(value);
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
		
		
		public void Write(OccupiedOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOccupied_order_sn() != null) {
				
				oprot.WriteFieldBegin("occupied_order_sn");
				oprot.WriteString(structs.GetOccupied_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcodes() != null) {
				
				oprot.WriteFieldBegin("barcodes");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.OccupiedOrderDetail _item0 in structs.GetBarcodes()){
					
					
					vipapis.normal.OccupiedOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OccupiedOrder bean){
			
			
		}
		
	}
	
}