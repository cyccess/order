#docker 编译文件

#基础镜像
FROM microsoft/aspnetcore:2.0
#定义参数
ARG source
#设置工作目录
WORKDIR /publish
#暴露端口
EXPOSE 3399
#把所有文件复制到工作目录
#COPY . /publish
#设置本地时间
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai  /etc/localtime
#程序入口 
ENTRYPOINT ["dotnet", "Psb.Wx.Web.dll"]

#挂载启动
#docker run -itd --name psb -p 3399:3399 -v /root/wwwroot/psb:/publish  baseaspnetcore dotnet Psb.Wx.Web.dll