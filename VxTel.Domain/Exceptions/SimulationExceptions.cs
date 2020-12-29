namespace VxTel.Domain.Exceptions
{
    public static class SimulationExceptions
    {
        public static void PlanNotFound()
        {
            throw new HttpResponseException
            {
                Status = 404,
                Value = "O plano selecionado não existe"
            };
        }

        public static void DddNoMatch()
        {
            throw new HttpResponseException
            {
                Status = 422,
                Value = "Os DDD enviados não compoem uma tarifa válida"
            };
        }
    }
}