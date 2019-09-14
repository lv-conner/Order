基于Blazor+Grpc+Worker Service作业。
项目目前存在以下问题
一、技术问题
1.使用Google.Protobuf生成的代码中，通讯消息类的string类型值不能设置为null。这是由于使用Proto3语法生成的string类型默认值为""空字符串。目前无解，除非更新代码生成器。
2.使用Worker Service技术如果使用Grpc.Core提供的Server使用一般HostedService进行寄宿，无法解决依赖注入的问题。目前发现的是使用Grpc.Core提供的Server中寄宿的Services作为单例存在。
3.Blazor类库目前尚不完善，微软当前只提供了服务端的模板。而客户端基于.net core的WebAssembly尚未提供。
4.Blazor App的认证和授权。
5.Grpc的认证和授权实现。
二、业务问题
1.Order Id的生成，目前使用Guid值截断实现，如果需要提供全局统一的流水号，可以使用Orleans或者Redis实现一个Order Id生成器。
2.目前没有日志记录、异常跟踪等功能。
