"""Utilities for cryptography

Contains functions for encoding, decoding, hashing, and formatting data.

Note:
    Some of the hashing algorithms are temporary and will be moved to run on
    separate threads. The attack algorithm should be multi-threaded as to
    maximize speed.

"""
import hashlib
from ecs

sha3_256 = hashlib.sha3_256()


def hash_func(data):
    """Returns a hash of the given data

    Notes:
        Uses SHA_3 256

    Args:
        data (str): Data to hash

    Returns:
        The hashed data
    """
    sha3_256.update(data.encode())
    return sha3_256.hexdigest()
