"""Node class definition

Each node has unique network and cryptographic information.

"""

import socket


class Node:
    """Defines the node type

    All nodes have a public key that is given to as many nodes as possible in
    the network. Killing a node requires finding a nonce that when hashed with
    the user's public key gives a certain leading pattern of bytes.

    A node's level is determined by how many kills they got it before they were
    killed themselves.

    Note:
        Only the user's node will have a private key.

    Attributes:
        address (IP_ADDRESS): The IP address of the node.
        public_key: This node's public key.
        private_key: This node's private key.
        level: This node's level.

    """

    def __init__(self, address, public_key, private_key = None):
        """Node object constructor

        Notes:
            The private key will be set to None if not given.

        Args:
            address (IP_ADDRESS): The IP address of the node.
            public_key (str): The node's public key.
            private_key (str): The node's private key.

        """
        self.address = socket.
        self.public_key = public_key
        self.private_key = private_key

    @staticmethod
    def create_new_user_node():
        """Creates a new user node

        The user node needs to generate a new key pair whenever it has been
        killed or the client first connects to the network.

        Args:
            i (int): A number to use.

        Returns
            A new

        """
        pass
