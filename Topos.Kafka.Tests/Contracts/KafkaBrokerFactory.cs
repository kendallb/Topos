﻿using Serilog;
using Topos.Config;
using Topos.Logging.Console;
using Topos.Tests.Contracts;

namespace Topos.Kafka.Tests.Contracts
{
    public class KafkaBrokerFactory : DisposableFactory, IBrokerFactory
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Info;

        public ToposProducerConfigurer ConfigureProducer()
        {
            return Configure
                .Producer(c => c.UseKafka(KafkaTestConfig.Address))
                .Logging(l => l.UseConsole(minimumLogLevel: LogLevel));
        }

        public ToposConsumerConfigurer ConfigureConsumer(string groupName)
        {
            return Configure
                .Consumer(groupName, c => c.UseKafka(KafkaTestConfig.Address))
                .Logging(l => l.UseConsole(minimumLogLevel: LogLevel));
        }

        public string GetNewTopic() => KafkaFixtureBase.GetTopic(Log.Logger);
    }
}