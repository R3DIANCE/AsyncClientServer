﻿using System;
using System.Collections.Generic;
using AsyncClientServer.Compression;
using AsyncClientServer.Cryptography;
using AsyncClientServer.Messaging.Metadata;

namespace AsyncClientServer.Server
{

	/// <summary>
	/// Interface for AsyncSocketListener
	/// <para>Implements <seealso cref="T:System.IDisposable" /></para>
	/// </summary>
	public interface IServerListener : IDisposable, ISendToClient
	{
		/// <summary>
		/// An event that is triggered when a message is received.
		/// </summary>
		event MessageReceivedHandler MessageReceived;

		/// <summary>
		/// Event that is triggered when a message has been send.
		/// </summary>
		event MessageSubmittedHandler MessageSubmitted;

		/// <summary>
		/// Event that is triggered when a client has disconnected from the server.
		/// </summary>
		event ClientDisconnectedHandler ClientDisconnected;

		/// <summary>
		/// Event that triggers when a client connects to the server.
		/// </summary>
		event ClientConnectedHandler ClientConnected;

		/// <summary>
		/// Event that is triggered when a file has been received from a client.
		/// </summary>
		event FileFromClientReceivedHandler FileReceived;

		/// <summary>
		/// Event that is triggered for every part of the message that is received from a client.
		/// </summary>
		event FileTransferProgressHandler ProgressFileReceived;

		/// <summary>
		/// Event that is triggered when the server has started.
		/// </summary>
		event ServerHasStartedHandler ServerHasStarted;
		
		/// <summary>
		/// Triggered when message failed to transmit
		/// </summary>
		event DataTransferToClientFailedHandler MessageFailed;

		/// <summary>
		/// Triggered when error is thrown
		/// </summary>
		event ServerErrorThrownHandler ErrorThrown;

		/// <summary>
		/// The port the server is running on
		/// </summary>
		int Port { get; }

		/// <summary>
		/// The ip the server is running on
		/// </summary>
		string Ip { get; }

		/// <summary>
		/// Used to encrypt files/folders
		/// </summary>
		Encryption MessageEncrypter { set; }

		/// <summary>
		/// Used to compress files before sending
		/// </summary>
		FileCompression ServerFileCompressor { set; }

		/// <summary>
		/// Used to compress folder before sending
		/// </summary>
		FolderCompression ServerFolderCompressor { set; }

		/// <summary>
		/// True if the server is currently running
		/// </summary>
		bool IsServerRunning { get;}

		/// <summary>
		/// Starts the server on a certain port
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		/// <param name="limit"></param>
		void StartListening(string ip, int port, int limit = 500);

		void StopListening();

		void ResumeListening();

		/// <summary>
		/// Checks if a client is connected
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool IsConnected(int id);

		/// <summary>
		/// Gets all currently connected clients
		/// </summary>
		/// <returns></returns>
		IDictionary<int, ISocketInfo> GetConnectedClients();

		/// <summary>
		/// Check a single client if he's still active
		/// </summary>
		/// <param name="id"></param>
		void CheckClient(int id);

		/// <summary>
		/// Checks all clients if they are still active and removes them if they are inactive.
		/// </summary>
		void CheckAllClients();

		/// <summary>
		/// Closes a certain client
		/// </summary>
		/// <param name="id"></param>
		void Close(int id);

		/// <summary>
		/// Change the BufferSize of the socket
		/// </summary>
		/// <param name="bufferSize"></param>
		void ChangeSocketBufferSize(int bufferSize);

	}
}
