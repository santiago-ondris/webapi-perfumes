namespace MasterNet.Domain
{
    public static class PolicyMaster
    {
        // Perfume
        public const string PERFUME_WRITE = nameof(PERFUME_WRITE);
        public const string PERFUME_READ = nameof(PERFUME_READ);
        public const string PERFUME_UPDATE = nameof(PERFUME_UPDATE);
        public const string PERFUME_DELETE = nameof(PERFUME_DELETE);
        // Ingrediente
        public const string INGREDIENTE_CREATE = nameof(INGREDIENTE_CREATE);
        public const string INGREDIENTE_READ = nameof(INGREDIENTE_READ);
        public const string INGREDIENTE_DELETE = nameof(INGREDIENTE_DELETE);
        public const string INGREDIENTE_UPDATE = nameof(INGREDIENTE_UPDATE);
        // Comentario
        public const string COMENTARIO_READ = nameof(COMENTARIO_READ);
        public const string COMENTARIO_DELETE = nameof(COMENTARIO_DELETE);
        public const string COMENTARIO_CREATE = nameof(COMENTARIO_CREATE);
    }
}