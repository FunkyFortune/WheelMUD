//-----------------------------------------------------------------------------
// <copyright file="FtpConnectionData.cs" company="WheelMUD Development Team">
//   Copyright (c) WheelMUD Development Team.  See LICENSE.txt.  This file is 
//   subject to the Microsoft Public License.  All other rights reserved.
// </copyright>
// <summary>//   
//   Created: 2004 By David McClarnon (dmcclarnon@ntlworld.com)
//   Modified: June 16, 2010 by Fastalanasa.
// </summary>
//-----------------------------------------------------------------------------

namespace WheelMUD.Ftp
{
    using System.Net.Sockets;
    using WheelMUD.Ftp.FileSystem;

	/// <summary>
	/// Contains all the data relating to a particular FTP connection
	/// </summary>
	public class FtpConnectionData
	{
		public FtpConnectionData(int id, TcpClient socket)
		{
            this.BinaryMode = false;
            this.RenameDirectory = false;
            this.PasvSocket = null;
            this.Id = id;
            this.Socket = socket;
            this.CurrentDirectory = "\\";
            this.PortCommandSocketAddress = "";
            this.PortCommandSocketPort = 20;
		}

	    /// <summary>
	    /// Main connection socket
	    /// </summary>
	    public TcpClient Socket { get; private set; }

	    public string User { get; set; }

	    /// <summary>
		/// This connection's current directory
		/// </summary>
        public string CurrentDirectory { get; set; }

	    /// <summary>
	    /// This connection's Id
	    /// </summary>
	    public int Id { get; private set; }

	    /// <summary>
		/// Socket address from PORT command.
		/// See FtpReplySocket class.
		/// </summary>
        public string PortCommandSocketAddress { get; set; }

		/// <summary>
		/// Port from PORT command.
		/// See FtpReplySocket class.
		/// </summary>
        public int PortCommandSocketPort { get; set; }

	    /// <summary>
	    /// Gets or sets a value indicating whether the connection is in binary or ASCII transfer mode.
	    /// </summary>
	    public bool BinaryMode { get; set; }

	    /// <summary>
	    /// If this is non-null the last command was a PASV and should therefore use this socket.
	    /// If this is null the last command was a PORT command and should therefore use that mechanism instead.
	    /// </summary>
	    public TcpClient PasvSocket { get; set; }

	    /// <summary>
	    /// Rename takes place with 2 commands - we store the old name here
	    /// </summary>
	    public string FileToRename { get; set; }

	    /// <summary>
	    /// This is true if the file to rename is a directory
	    /// </summary>
	    public bool RenameDirectory { get; set; }

        public IFileSystem FileSystemObject { get; private set; }

		protected void SetFileSystemObject(IFileSystem fileSystem)
		{
			this.FileSystemObject = fileSystem;
		}
	}
}