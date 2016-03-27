using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APISOA.Controllers
{
    public class TarjetaCreditoController : ApiController
    {
        SOATarjetaCredito.TarjetaCreditoPortType_v1Client tarjetaCreditoCliente;

        public SOATarjetaCredito.RespConsultaLimites Get()
        {
            tarjetaCreditoCliente = new SOATarjetaCredito.TarjetaCreditoPortType_v1Client();
            SOATarjetaCredito.SoapHeaderReq headerReq = new SOATarjetaCredito.SoapHeaderReq();
            SOATarjetaCredito.SoapHeaderRes headerRes = new SOATarjetaCredito.SoapHeaderRes();

            headerReq.sessionContext = new SOATarjetaCredito.SessionContext();
            headerReq.sessionContext.clientId = new SOATarjetaCredito.SessionContextClientId();
            headerReq.sessionContext.clientId.country = "80";
            headerReq.sessionContext.clientId.idType = "4";
            headerReq.sessionContext.clientId.id = "24235623";

            headerReq.sessionContext.session = new SOATarjetaCredito.SessionContextSession();
            headerReq.sessionContext.session.canalID = "Cortana";
            headerReq.sessionContext.session.id = "HGari";
            headerReq.sessionContext.session.userName = "hg35623";
            headerReq.sessionContext.session.systemId = "Cortana";

            headerReq.sessionContext.clientDescription = "Prueba Cortana";


            SOATarjetaCredito.ReqConsultaLimites req = new SOATarjetaCredito.ReqConsultaLimites();
            SOATarjetaCredito.RespConsultaLimites resp = new SOATarjetaCredito.RespConsultaLimites();

            SOATarjetaCredito.DataConsultaLimitesReqType data = new SOATarjetaCredito.DataConsultaLimitesReqType();

            SOATarjetaCredito.IdTarjetaType identificador = new SOATarjetaCredito.IdTarjetaType();
            identificador.dataTypeName = "Argencard S.A.";
            identificador.idTarjeta = "5243485860597128";
            data.identificador = identificador;
            req.Data = data;
            headerRes = tarjetaCreditoCliente.consultaLimites(headerReq, req, out resp);
            return resp;
        }


    }
}
