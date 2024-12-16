#!/bin/bash
set -x

# Get the current number of chatconsole containers running
num_consoles=$(docker ps -f "name=chatconsole" --format "{{.Names}}" | wc -l)

# Calculate the next available USER_ID (e.g., user1, user2, ...)
user_id="user$((num_consoles + 1))"

# Set the USER_ID as an environment variable
export USER_ID=$user_id

# Dynamically find the next available port starting from 7892
base_port=7892
next_port=$((base_port + 1))

# Check if the port is already in use, increment if it is
while [[ $(docker ps --filter "publish=$next_port" -q) ]]; do
  echo "Port $next_port is already in use, checking next port..."
  next_port=$((next_port + 1))
done

# Set the dynamic PORT variable
export PORT=$next_port

# Create a new chatconsole instance using docker-compose with a new port and user_id
docker-compose run -d \
  -e USER_ID=$USER_ID \
  -e PORT=$PORT \
  --name "chatconsole-$USER_ID" \
  chatconsole

# Inform the user of the new instance and port
echo "Created new chatconsole instance with USER_ID: $user_id, using port $PORT"
