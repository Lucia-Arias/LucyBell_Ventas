﻿namespace LucyBell_Ventas.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T entidad);
    }
}