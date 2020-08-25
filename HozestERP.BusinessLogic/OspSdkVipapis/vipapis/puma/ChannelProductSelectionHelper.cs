using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class ChannelProductSelectionHelper : TBeanSerializer<ChannelProductSelection>
	{
		
		public static ChannelProductSelectionHelper OBJ = new ChannelProductSelectionHelper();
		
		public static ChannelProductSelectionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelProductSelection structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("desc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDesc(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStock(value);
					}
					
					
					
					
					
					if ("freight".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFreight(value);
					}
					
					
					
					
					
					if ("pics".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPics(value);
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
		
		
		public void Write(ChannelProductSelection structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDesc() != null) {
				
				oprot.WriteFieldBegin("desc");
				oprot.WriteString(structs.GetDesc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteString(structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteString(structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock() != null) {
				
				oprot.WriteFieldBegin("stock");
				oprot.WriteString(structs.GetStock());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFreight() != null) {
				
				oprot.WriteFieldBegin("freight");
				oprot.WriteString(structs.GetFreight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPics() != null) {
				
				oprot.WriteFieldBegin("pics");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetPics()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelProductSelection bean){
			
			
		}
		
	}
	
}