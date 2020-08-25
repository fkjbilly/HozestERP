using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetMultiPoPickDetailResponseHelper : TBeanSerializer<GetMultiPoPickDetailResponse>
	{
		
		public static GetMultiPoPickDetailResponseHelper OBJ = new GetMultiPoPickDetailResponseHelper();
		
		public static GetMultiPoPickDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetMultiPoPickDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pick_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.MultiPickDetailInfo> value;
						
						value = new List<vipapis.delivery.MultiPickDetailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.MultiPickDetailInfo elem1;
								
								elem1 = new vipapis.delivery.MultiPickDetailInfo();
								vipapis.delivery.MultiPickDetailInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPick_detail_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetMultiPoPickDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPick_detail_list() != null) {
				
				oprot.WriteFieldBegin("pick_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.MultiPickDetailInfo _item0 in structs.GetPick_detail_list()){
					
					
					vipapis.delivery.MultiPickDetailInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetMultiPoPickDetailResponse bean){
			
			
		}
		
	}
	
}