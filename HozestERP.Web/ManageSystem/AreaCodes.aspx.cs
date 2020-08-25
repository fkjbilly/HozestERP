using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageSystem
{
    public partial class AreaCodes : BaseAdministrationPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Page.Theme = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, DirectEventArgs e)
        {
            var areaCode = AreaCodeService.GetAreaByNumberID(formID.Text);
            areaCode.City = txtCity.Text;
            areaCode.PrePath = txtPrePath.Text;
            areaCode.Spell = txtSpell.Text;
            areaCode.shortening = txtshortening.Text;
            areaCode.Post = txtPost.Text;
            areaCode.AreaID = txtAreaID.Text;
            areaCode.CityType = txtCityType.Text;
            AreaCodeService.UpdateAreaCode(areaCode);
        }

        protected void btnSave_Click(object sender, DirectEventArgs e)
        {
            string id = formID.Text;
            string Preceding = string.Empty;
            string numberID = string.Empty;
            List<BusinessLogic.Codes.AreaCode> list = new List<BusinessLogic.Codes.AreaCode>();

            if(string.IsNullOrEmpty(id))
            {
                list= base.AreaCodeService.GetAreaCode("001");
                Preceding = "001";
            }
            else
            {
                list = base.AreaCodeService.GetAreaCode(id);
                Preceding = id;
            }

            if(list.Count>0)
            {
                string ID = list.OrderByDescending(a => a.NumberID).ToList()[0].NumberID;
                numberID = "00"+(int.Parse(ID) + 1).ToString();
            }
            else
            {
                numberID = id + "001";
            }

            AreaCodeService.InsertAreaCode(new BusinessLogic.Codes.AreaCode()
            {
                NumberID = numberID,
                Root = "001",
                Preceding = Preceding,
                PrePath = txtPrePath.Text,
                Rank = txtPrePath.Text.Split('/').Count()+1,
                City= txtCity.Text,
                CityType= txtCityType.Text,
                Govt=0,
                Post= txtPost.Text,
                AreaID= txtAreaID.Text,
                shortening= txtshortening.Text,
                Spell= txtSpell.Text,
                KeyWord="",
                OrderStr=0,
                Acreage=0,
                Population=0,
                Enabled=false,
            });
        }

        protected void del_Click(object sender, DirectEventArgs e)
        {
            string ID = e.ExtraParams["ID"];

            if(string.IsNullOrEmpty(ID))
            {

            }
        }
    }
}