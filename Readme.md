����Blazor+Grpc+Worker Service��ҵ��
��ĿĿǰ������������
һ����������
1.ʹ��Google.Protobuf���ɵĴ����У�ͨѶ��Ϣ���string����ֵ��������Ϊnull����������ʹ��Proto3�﷨���ɵ�string����Ĭ��ֵΪ""���ַ�����Ŀǰ�޽⣬���Ǹ��´�����������
2.ʹ��Worker Service�������ʹ��Grpc.Core�ṩ��Serverʹ��һ��HostedService���м��ޣ��޷��������ע������⡣Ŀǰ���ֵ���ʹ��Grpc.Core�ṩ��Server�м��޵�Services��Ϊ�������ڡ�
3.Blazor���Ŀǰ�в����ƣ�΢��ǰֻ�ṩ�˷���˵�ģ�塣���ͻ��˻���.net core��WebAssembly��δ�ṩ��
4.Blazor App����֤����Ȩ��
5.Grpc����֤����Ȩʵ�֡�
����ҵ������
1.Order Id�����ɣ�Ŀǰʹ��Guidֵ�ض�ʵ�֣������Ҫ�ṩȫ��ͳһ����ˮ�ţ�����ʹ��Orleans����Redisʵ��һ��Order Id��������
2.Ŀǰû����־��¼���쳣���ٵȹ��ܡ�
