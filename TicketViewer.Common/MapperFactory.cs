namespace TicketViewer.Common
{
    public static class MapperFactory
    {
        private static AutoMapper.IMapper _mapper;

        public static void InitializeMapper(params string[] assemblyNamesToScan)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblyNamesToScan);
            });

            _mapper = config.CreateMapper();
        }

        public static AutoMapper.IMapper GetInstance()
        {
            return _mapper;
        }
    }
}
