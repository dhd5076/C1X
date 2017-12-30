"""Main file for the program

C1X is a distributed cryptography-based game that relies on computing power in
order to win.

TODO:
    This isn't implemented as stated and a lot of tasks here should be
    moved to better classes and functions.

"""
import socket

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

host = socket.gethostbyname()

port = 8090


def main():
    """Entry point to the program

    Starts up several different processes including loading up node information
    and connect to the network.

    """
    server_socket.bind(host, port)
    clientsocket,addr = server_socket.accept()
    print(str(addr))


if __name__ == "__main__":
    """Calls main if we are running as main."""
    main()
