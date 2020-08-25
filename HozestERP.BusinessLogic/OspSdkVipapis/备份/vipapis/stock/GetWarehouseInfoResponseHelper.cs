using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class GetWarehouseInfoResponseHelper : BeanSerializer<GetWarehouseInfoResponse>
	{
		
		public static GetWarehouseInfoResponseHelper OBJ = new GetWarehouseInfoResponseHelper();
		
		public static GetWarehouseInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetWarehouseInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse_info_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.WarehouseInfoList> value;
						
						value = new List<vipapis.stock.WarehouseInfoList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.WarehouseInfoList elem0;
								
								elem0 = new vipapis.stock.WarehouseInfoList();
								vipapis.stock.WarehouseInfoListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetWarehouse_info_list(value);
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
		
		
		public void Write(GetWarehouseInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse_info_list() != null) {
				
				oprot.WriteFieldBegin("warehouse_info_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.WarehouseInfoList _item0 in structs.GetWarehouse_info_list()){
					
					
					vipapis.stock.WarehouseInfoListHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetWarehouseInfoResponse bean){
			
			
		}
		
	}
	
}