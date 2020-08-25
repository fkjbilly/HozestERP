#ifndef _DLL_PRINTERMANAGER_H
#define _DLL_PRINTERMANAGER_H
#pragma once

#ifdef PRINTERMANAGER_EXPORTS
#define DLL_PRINTERMANAGER_API __declspec(dllexport)
#else
#define DLL_PRINTERMANAGER_API __declspec(dllimport)
#endif

#include <iostream>
#include <WinSock2.h>
#include <assert.h>
#include <stdio.h>
#include <string>
#include "easywsclient/easywsclient.hpp"

using namespace std;
using easywsclient::WebSocket;
typedef void(*_onMessage_func)(const std::string &message);

class DLL_PRINTERMANAGER_API PrinterManager
{
private:
	WebSocket::pointer websocket;//websocket����
	string url;//���ӡ����������ʹ�õ�URL
	_onMessage_func funcPtr;//�ص�����ָ��
	HANDLE hMutex;//�˻��������ڷ�ֹwebsocket�еĶ�д�������Ķ��߳����ݲ���ȫ
public:
	HANDLE hRecvThread;//�����߳̾��
	
public:
	PrinterManager();
	PrinterManager(string url);
	~PrinterManager();

	///����Ϊ�ӿں���
	/*��������
	message��ʾҪ���͵��ַ���
	enCodeMode��ʾ���뷽ʽ
	*/
	int sendMessage(const std::string &message, const std::string &enCodeMode = "UTF8");
	//�趨�ص�������funcΪ�ص�����ָ��
	int setRecvDataCallback(_onMessage_func func);
	int close();
private:
	//��ʼ��wsa
	void initWSA();

	//���������߳���ʼ������lpParameterΪ
	static DWORD WINAPI RecvThread(LPVOID lpParameter);
	void initThread();//��ʼ���߳�

	//�����������ݣ����յ�������ת��handle_Message��������	
	int listener();
	//�����еľ�̬handle_Message�����������printerָ����ò�ͬ�����handleMessage����
	static void handle_message(const std::string & message,void *printer=NULL);
	//����Ľ��պʹ������ݵĺ���������ִ�лص�����
	void handleMessage(const std::string &message); 
	//��GBK����תΪUTF8����
	static string GBKToUTF8(const std::string& strGBK);
	
};

#undef DLL_PRINTERMANAGER_API

#endif

