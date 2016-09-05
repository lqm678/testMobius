﻿using System;
using PowerArgs;

namespace kafkaStreamTest
{
    [Serializable]
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    public class ArgOptions
    {
        #region Kafka settings
        [ArgDefaultValue("localhost:9092"), ArgDescription("Kafka metadata.broker.list (separated by ',' if multiple)")]
        public String BrokerList { get; set; }


        [ArgDefaultValue("localhost:2181"), ArgDescription("Zookeeper connection string (separated by ',' if multiple)")]
        public String Zookeeper { get; set; }


        [ArgDefaultValue("smallest"), ArgDescription("auto.offset.reset")]
        public String AutoOffset { get; set; }


        [ArgDefaultValue("lzKafkaTestGroup"), ArgDescription("Kafka group id")]
        public String GroupId { get; set; }


        [ArgDefaultValue(-1), ArgDescription("Kafka topic fromOffset")]
        public long FromOffset { get; set; }


        [ArgDefaultValue(-1), ArgDescription("Kafka topic untilOffset")]
        public long UntilOffset { get; set; }

        #endregion

        #region Spark streaming settings

        [ArgShortcut("b"), ArgDescription("batch seconds"), ArgDefaultValue(1), ArgRange(1, 999)]
        public int BatchSeconds { get; set; }

        [ArgShortcut("w"), ArgDescription("window seconds"), ArgDefaultValue(4)]
        public int WindowSeconds { get; set; }

        [ArgShortcut("s"), ArgDescription("slide seconds"), ArgDefaultValue(4)]
        public int SlideSeconds { get; set; }

        [ArgShortcut("c"), ArgDefaultValue("checkDir"), ArgExample("checkDir", "check point directory")]
        public string CheckPointDirectory { get; set; } // = Path.Combine(Path.GetTempPath(), "checkDir")

        [ArgShortcut("f"), ArgDefaultValue(""), ArgDescription("save file directory, not save if empty.")]
        public string SaveTxtDirectory { get; set; }

        #endregion

        #region Application settings

        [ArgShortcut("r"), ArgDescription("Running seconds"), ArgDefaultValue(30)]
        public int RunningSeconds { get; set; }

        [ArgShortcut("d"), ArgDefaultValue(0), ArgDescription("Times to delete check point directory before each test")]
        public int DeleteCheckPointDirectoryTimes { get; set; }

        [ArgDefaultValue(0), ArgDescription("Wait seconds for user to attach this process and debug.")]
        public int WaitSecondsForAttachDebug { get; set; }

        [ArgShortcut("t"), ArgDescription("Test times"), ArgDefaultValue(1)]
        public int TestTimes { get; set; }

        [ArgShortcut("i"), ArgDescription("Interval seconds between tests"), ArgDefaultValue(0), ArgRange(0, int.MaxValue)]
        public int TestIntervalSeconds { get; set; }

        #endregion

        [HelpHook, ArgDescription("Shows this help"), ArgShortcut("-h")]
        public bool Help { get; set; }
    }
}
