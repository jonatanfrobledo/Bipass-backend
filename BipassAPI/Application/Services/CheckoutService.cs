using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

// ⚠️ Descomentar estos 'using' cuando tengas el Access Token de Mercado Pago
// using MercadoPago.Client.Preference;
// using MercadoPago.Config;
// using MercadoPago.Resource.Preference;

namespace Infraestructure.Services
{
    public class CheckoutService
    {
        private readonly IConfiguration _configuration;

        public CheckoutService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreatePreferenceAsync(OrderDto order)
        {
            // =========================================================================
            // 🧪 1. FUNCIONALIDAD TEMPORAL / MOCK (ACTIVA)
            // =========================================================================
            // Simula latencia de red para probar el flujo de compra en el Frontend React
            await Task.Delay(500);

            // Genera un ID de preferencia falso para que React pueda continuar al siguiente paso sin dar error 403
            string mockPreferenceId = "PREFERENCE_MOCK_" + Guid.NewGuid().ToString("N");

            return mockPreferenceId;


            // =========================================================================
            // 💳 2. CÓDIGO REAL DE MERCADO PAGO (DESCOMENTAR CUANDO TENGAS EL ACCESS TOKEN)
            // =========================================================================
            /*
            // A. Obtener token desde appsettings.json
            var token = _configuration["MercadoPago:AccessToken"];
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("El token de Mercado Pago 'MercadoPago:AccessToken' no está configurado en appsettings.json.");
            }

            // B. Configurar el Access Token en el SDK global
            MercadoPagoConfig.AccessToken = token;

            // C. Armar el request de la preferencia
            var request = new PreferenceRequest
            {
                Items = order.OrderItems.Select(item => new PreferenceItemRequest
                {
                    Title = item.TicketType?.Name ?? "Entrada de Evento",
                    Quantity = item.Quantity,
                    CurrencyId = "ARS",
                    UnitPrice = item.UnitPrice
                }).ToList(),

                // Redirecciones de éxito, falla o pendiente para el Frontend
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:5173/checkout/success",
                    Failure = "http://localhost:5173/checkout/failure",
                    Pending = "http://localhost:5173/checkout/pending"
                },
                AutoReturn = "approved",

                // Vincula el ID de tu orden de BD con la transacción de Mercado Pago (clave para los Webhooks)
                ExternalReference = order.Id.ToString(),

                // URL para notificaciones de pagos en tiempo real (requiere ngrok en local)
                // NotificationUrl = "https://tu-dominio-ngrok.ngrok-free.app/api/webhooks/mercadopago"
            };

            // D. Crear la preferencia en Mercado Pago
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            // Retornamos el ID de la preferencia para montarlo con el SDK en React
            return preference.Id;
            */
        }
    }
}